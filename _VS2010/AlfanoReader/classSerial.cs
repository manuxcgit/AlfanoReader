using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace AlfanoReader
{
    public enum enumEventArgConnecte { connecté, deconnecté, dataReceived, fichierCréé, transfertCompleted };
    
    
    public class classParamSerial
    {
        int _baudRate;
        Parity _parity;
        int _dataBits;
        StopBits _stopBit;
        string _portName;

        public classParamSerial() { }

        public classParamSerial(string portname, int baubrate, Parity parity, int databits, StopBits stopbit)
        {
            _portName = portname;
            _baudRate = baubrate;
            _parity = parity;
            _dataBits = databits;
            _stopBit = stopbit;
        }

        public string PortName { get { return _portName; } set { } }
        public int BaudRate { get { return _baudRate; } set { } }
        public Parity Parity { get { return _parity; } set { } }
        public int DataBits { get { return _dataBits; } set { } }
        public StopBits StopBit { get { return _stopBit; } set { } }
    }
    
    public class classSerial 
    {
        #region definitions
        public event EventHandler<EventArgsConnecte> eventInfosSerial;        //renvoie vers formMain string { connecté, deconnecté, fichier créé, transfert en cours }       
        public string PortName { get { return _serialPort.PortName; } }
        public int BytesReceived { get { return _serialPort.BytesToRead; } }

        private bool _isConnected = false;
        private SerialPort _serialPort;
        public classParamSerial _ParamSerial { get; set; }
        #endregion

        //public classSerial() { }

        public classSerial(classParamSerial paramSerial)
        {
            try
            {
                _ParamSerial = paramSerial;
                _serialPort = new SerialPort(paramSerial.PortName, paramSerial.BaudRate, paramSerial.Parity, paramSerial.DataBits, paramSerial.StopBit);
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            }
            catch { }
        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            eventInfosSerial(this, new EventArgsConnecte(enumEventArgConnecte.dataReceived));
            if (_serialPort.BytesToRead == 2048) 
            { eventInfosSerial(this, new EventArgsConnecte(enumEventArgConnecte.transfertCompleted)); }
        }


        #region methodes publiques
        public Boolean m_open()
        {
            try
            {
                _serialPort.Open();
                eventInfosSerial(this, new EventArgsConnecte(enumEventArgConnecte.connecté));
            }
            catch (Exception e) { }
            return _serialPort.IsOpen;
        }

        public void m_close()
        {
            try
            {
                // eventInfosSerial(this, new EventArgsConnecte(enumEventArgConnecte.deconnecté));
                _serialPort.Close();
            }
            catch { }
        }

        public bool m_save(string nomFichier)
        {
            try
            {
                BinaryReader br = null;
                BinaryWriter bw = null;
                FileStream fs = null;
                //Ecriture d'octets dans le fichier
                bw = new BinaryWriter(File.Create(nomFichier));
                while (_serialPort.BytesToRead > 0)
                {
                    bw.Write((byte)_serialPort.ReadByte());
                    //        car = String.Format("{0:X} ", bit);
                    //        if (car.Trim().Length == 1) { car = "0" + car; }
                }
                bw.Flush();
                bw.Close();
                eventInfosSerial(this, new EventArgsConnecte(enumEventArgConnecte.fichierCréé));
                return true;
            }
            catch { return false; }
        }
        #endregion
    }

    public class EventArgsConnecte : EventArgs
    {

        public enumEventArgConnecte Arg { get; private set; }
        public EventArgsConnecte(enumEventArgConnecte arg)
        {
            this.Arg = arg;
        }
    }
}