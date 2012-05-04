using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;

namespace AlfanoReader
{
    class classSerial
    {
        private SerialPort _serialPort;
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
        public event SerialDataReceivedEventHandler DataReceived;
        public event EventHandler DataCompleted;
        public event EventHandler<EventArgsConnecte> ConnectOrDisconnect;

        public classSerial(classParamSerial serial)
        {
            _serialPort = new SerialPort(serial.PortName, serial.BaudRate, serial.Parity, serial.DataBits, serial.StopBit);
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
        }

        public string PortName { get { return _serialPort.PortName; } }

        public int BytesReceived { get { return _serialPort.BytesToRead; } }

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DataReceived(this, e);
            if (_serialPort.BytesToRead == 2048) { DataCompleted(this, null); }
        }

        public Boolean m_open()
        {
            try
            {
                _serialPort.Open();
                ConnectOrDisconnect(this, new EventArgsConnecte("Connecté à " + _serialPort.PortName));
            }
            catch (Exception e) { }
            return _serialPort.IsOpen;
        }

        public void m_close()
        {
            try
            {
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
                ConnectOrDisconnect(this, new EventArgsConnecte(new FileInfo(nomFichier).Name + " crée"));
                return true;
            }
            catch { return false; }
        }


    }
    public class EventArgsConnecte : EventArgs
    {

        public string Mode { get; private set; }
        public EventArgsConnecte(string mode)
        {
            this.Mode = mode;
        }
    }
}