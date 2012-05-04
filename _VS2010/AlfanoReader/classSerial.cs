using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace AlfanoReader
{
    enum enumEventArgConnecte { connecté, deconnecté, dataReceived, fichierCréé, transfertCompleted };

    class classSerial
    {
        #region definitions
        public class classParamSerial
        {
            int _baudRate;
            Parity _parity;
            int _dataBits;
            StopBits _stopBit;
            string _portName;

            public classParamSerial(string portname, int baubrate, Parity parity, int databits, StopBits stopbit)
            {
                _portName = portname;
                _baudRate = baubrate;
                _parity = parity;
                _dataBits = databits;
                _stopBit = stopbit;
            }

            public string PortName { get { return _portName; } }
            public int BaudRate { get { return _baudRate; } }
            public Parity Parity { get { return _parity; } }
            public int DataBits { get { return _dataBits; } }
            public StopBits StopBit { get { return _stopBit; } }
        }
        public event EventHandler<EventArgsConnecte> eventInfosSerial;        //renvoie vers formMain string { connecté, deconnecté, fichier créé, transfert en cours }       
        public string PortName { get { return _serialPort.PortName; } }
        public int BytesReceived { get { return _serialPort.BytesToRead; } }

        private Thread threadWatchConnection;
        private bool _isConnected = false;
        private SerialPort _serialPort;
        #endregion

        public classSerial(classParamSerial serial)
        {
            _serialPort = new SerialPort(serial.PortName, serial.BaudRate, serial.Parity, serial.DataBits, serial.StopBit);
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
        }

        public classParamSerial ParamSerial { get; set;}

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            eventInfosSerial(this, new EventArgsConnecte(enumEventArgConnecte.dataReceived));
            if (_serialPort.BytesToRead == 2048) { eventInfosSerial(this, new EventArgsConnecte(enumEventArgConnecte.transfertCompleted)); }
        }

        private void watchConnection()
        {
            while (_isConnected) { System.Windows.Forms.Application.DoEvents(); }
            eventInfosSerial(this, new EventArgsConnecte(enumEventArgConnecte.deconnecté));
        }

        #region methodes publiques
        public Boolean m_open()
        {
            try
            {
                _serialPort.Open();
                eventInfosSerial(this, new EventArgsConnecte(enumEventArgConnecte.connecté));
                _isConnected = true;
                threadWatchConnection = new Thread(watchConnection);
                threadWatchConnection.Start();
            }
            catch (Exception e) { }
            return _serialPort.IsOpen;
        }

        public void m_close()
        {
            try
            {
                _serialPort.Close();
                _isConnected = false;
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

    class EventArgsConnecte : EventArgs
    {

        public enumEventArgConnecte Arg { get; private set; }
        public EventArgsConnecte(enumEventArgConnecte arg)
        {
            this.Arg= arg;
        }
    }
}