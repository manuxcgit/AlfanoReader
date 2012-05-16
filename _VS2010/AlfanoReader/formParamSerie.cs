using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;


namespace AlfanoReader
{

    public partial class formParamSerie : Form
    {
        
        public classSerial _serial;
        public formParamSerie(ref classSerial serial)
        {
            InitializeComponent();
            _serial = serial;
            cBPortName.Items.AddRange(SerialPort.GetPortNames());
            cBPortName.Text = _serial.PortName;
            cBBaudRate.Items.AddRange(new string[] { "2400", "9600", "14400", "19200", "38400", "57600", "115200" });
            cBBaudRate.Text = _serial._ParamSerial.BaudRate.ToString();
            cBDataBits.Items.AddRange(new string[] { "4", "5", "6", "7", "8" });
            cBDataBits.Text = _serial._ParamSerial.DataBits.ToString();
            cBParity.Items.AddRange(Enum.GetNames(typeof(Parity)));
            cBParity.Text = _serial._ParamSerial.Parity.ToString();
            cBStopBit.Items.AddRange(Enum.GetNames(typeof(StopBits)));
            cBStopBit.Text = _serial._ParamSerial.StopBit.ToString();
        }

        private void e_cmdAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void e_cmdValider_Click(object sender, EventArgs e)
        {
            try
            {
                Parity p = (Parity)Enum.GetNames(typeof(Parity)).ToList().FindIndex(x => x.Equals(cBParity.Text));
                StopBits s = (StopBits)Enum.GetNames(typeof(StopBits)).ToList().FindIndex(y => y.Equals(cBStopBit.Text));
                _serial._ParamSerial = new classParamSerial(
                    cBPortName.Text,
                    int.Parse(cBBaudRate.Text),
                    p,
                    int.Parse(cBDataBits.Text),
                    s);
                this.DialogResult = DialogResult.OK;
            }
            catch { }
        }
    }
}
