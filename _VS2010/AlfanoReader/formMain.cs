using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace AlfanoReader
{


    public partial class formMain : Form
    {

        classSerial _serial;
        private bool _transferCompleted;
        private delegate void delegate_eventInfosSerial(enumEventArgConnecte arg);
        private FileInfo _FichierAlfano;

        public formMain()
        {
            InitializeComponent();
            paramApplication.setFileName("param.xml");
        }

        #region Connection Port Serie + creation FichierAlfano
        private void e_ToolStripMenuItemimporterDepuisAlfano_Click(object sender, EventArgs e)
        {
            try
            {
                classSerial.classParamSerial _paramPortSerie = (classSerial.classParamSerial)paramApplication.LoadFromXML(typeof(classSerial.classParamSerial));
                _serial = new classSerial(new classSerial.classParamSerial("COM3", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One));

               // paramApplication.SaveToXml(_serial.ParamSerial.BaudRate, typeof(int));
                paramApplication.SaveToXml(_serial.ParamSerial, typeof(classSerial.classParamSerial));

                _serial.eventInfosSerial += new EventHandler<EventArgsConnecte>(_handler_eventInfosSerial);
                if (!_serial.m_open())
                {
                    MessageBox.Show("PROBLEME DE PORT SERIE", "Impossible d'ouvrir le port série", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e1){ }
        }

        void _handler_eventInfosSerial(object sender, EventArgsConnecte e)
        {
            this.Invoke(new delegate_eventInfosSerial(traite_eventInfosSerial), e.Arg);
        }

        void traite_eventInfosSerial(enumEventArgConnecte arg)
        {
            switch (arg)
            {
                case enumEventArgConnecte.connecté:
                    {
                        toolStripStatusLabelInfo.Text = "Connecté à " + _serial.PortName;
                        break;
                    }
                case enumEventArgConnecte.dataReceived:
                    {
                        try { toolStripProgressBar.Value = _serial.BytesReceived; }
                        catch { }
                        Application.DoEvents();
                        break;
                    }
                case enumEventArgConnecte.deconnecté:
                    {
                        toolStripStatusLabelInfo.Text += "Déconnecté";
                        break;
                    }
                case enumEventArgConnecte.fichierCréé:
                    {
                        toolStripStatusLabelInfo.Text = _FichierAlfano.Name + " créé";
                        break;
                    }
                case enumEventArgConnecte.transfertCompleted:
                    {
                        serial_dataCompleted();
                        break;
                    }
            }
        }

        void serial_dataCompleted()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (!sfd.FileName.ToLower().EndsWith(".alf"))
                {
                    sfd.FileName += ".alf";
                }
                if (_serial.m_save(sfd.FileName))
                {
                    toolStripProgressBar.Value = 0;
                    _transferCompleted = true;
                }
            }
        }
        #endregion

        private void e_ToolStripMenuItemquitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void e_formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (MessageBox.Show("Voulez vous quitter ?", "QUITTER",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No);
        }
    }
}