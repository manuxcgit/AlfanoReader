﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.IO.Ports;




namespace AlfanoReader
{


    public partial class formMain : Form
    {

        classSerial _serial;
        private delegate void delegate_eventInfosSerial(enumEventArgConnecte arg);
        private FileInfo _FichierAlfano;


        public formMain()
        {
            InitializeComponent();
            paramApplication.setFileName("parametres");

            _serial = new classSerial(paramApplication.LoadFromXML<classParamSerial> ( new classParamSerial()));
            if (_serial._ParamSerial == null)
            {                
                _serial = new classSerial(new classParamSerial
                {
                    PortName = "COM3",
                    BaudRate = 9600,
                    Parity = System.IO.Ports.Parity.None,
                    DataBits = 8,
                    StopBit = System.IO.Ports.StopBits.One
                });
            }
            ToolStripMenuItemportSerie.Enabled = true;
        }

        #region Connection Port Serie + creation FichierAlfano
        private void e_ToolStripMenuItemimporterDepuisAlfano_Click(object sender, EventArgs e)
        {
            m_serialConnect();
        }

        private void m_serialConnect()
        {
            try
            {
                _serial.eventInfosSerial += new EventHandler<EventArgsConnecte>(_handler_eventInfosSerial);
                if (!_serial.m_open())
                {
                    MessageBox.Show("Impossible d'ouvrir le port série", "PROBLEME DE PORT SERIE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolStripStatusLabelInfo.Text = "Pas de connection";
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
                        toolStripStatusLabelInfo.Text = "Connecté à " + _serial.PortName + " , attend Transfert";
                        break;
                    }
                case enumEventArgConnecte.dataReceived:
                    {
                        try
                        {
                            toolStripProgressBar.Value = _serial.BytesReceived;
                            toolStripStatusLabelInfo.Text = string.Format("Transfert en cours, {0}% effectué", (_serial.BytesReceived * 100) / 2048);
                        }
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
                _FichierAlfano = new FileInfo(sfd.FileName);
                if (_serial.m_save(sfd.FileName))
                {
                    toolStripProgressBar.Value = 0;
                }
                else { _FichierAlfano = null; }
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

        private void e_formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try {
                _serial.m_close();
                paramApplication.SaveToXml(_serial._ParamSerial);
            }
            catch { }
        }

        private void e_ToolStripMenuItemportSerie_Click(object sender, EventArgs e)
        {
            formParamSerie fPS = new formParamSerie(ref _serial);
            if (fPS.ShowDialog() == DialogResult.OK)
            {
                _serial = new classSerial(_serial._ParamSerial);
                m_serialConnect();
            }
        }
    }
}