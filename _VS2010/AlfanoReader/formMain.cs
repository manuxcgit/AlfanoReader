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
        private delegate void ProgressBarDelegateInProgressHandler(int percent);
        private ProgressBarDelegateInProgressHandler objProgressBarDelegateInProgress;
        private delegate void delegate_progressbarupdate();
        private delegate void delegate_dataCompleted();
        private delegate void delegate_connectedordisconnected(object sender, EventArgsConnecte e);

        public formMain()
        {
            InitializeComponent();

        }

        private void e_ToolStripMenuItemimporterDepuisAlfano_Click(object sender, EventArgs e)
        {
            try
            {
                _serial = new classSerial(new classSerial.classParamSerial("COM3", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One));
                _serial.ConnectOrDisconnect += new EventHandler<EventArgsConnecte>(_serial_ConnectOrDisconnect);
                if (!_serial.m_open())
                {
                    MessageBox.Show("PROBLEME DE PORT SERIE", "Impossible d''ouvrir le port série", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //toolStripStatusLabelInfo.Text = "Connecté à " + _serial.PortName;
                    _serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(_serial_DataReceived);
                    _serial.DataCompleted += new EventHandler(_serial_DataCompleted);
                    _transferCompleted = false;
                    Thread threadWFCompleted = new Thread(WaitToDisconnect);
                    threadWFCompleted.Start();
                }
            }
            catch { }
        }

        private void WaitToDisconnect()
        {
            while (!_transferCompleted) { Application.DoEvents(); }
            _serial.m_close();
            toolStripStatusLabelInfo.Text += ", port série déconnecté";
        }

        void connectedOrDisconnected(object sender, EventArgsConnecte e)
        {
            toolStripStatusLabelInfo.Text = e.Mode;
        }

        void dataCompleted()
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

        void progressBarUpdate()
        {
            try { toolStripProgressBar.Value = _serial.BytesReceived; }
            catch { }
        }

        void _serial_DataCompleted(object sender, EventArgs e)
        {
            this.Invoke(new delegate_dataCompleted(dataCompleted));
        }

        void _serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            this.Invoke(new delegate_progressbarupdate(progressBarUpdate));
        }

        void _serial_ConnectOrDisconnect(object sender, EventArgsConnecte e)
        {
            this.Invoke(new delegate_connectedordisconnected(connectedOrDisconnected), sender, e);
        }

        /*
                private void e_cmdConnecter_Click(object sender, EventArgs e)
                {
                    if (cmdConnecter.Text == "Connecter")
                    {
                        serialPort.Open();
                        cmdConnecter.Text = "Quitter";
                        threadRead = new Thread(Read);
                        threadRead.Start();
                        _continue = true;
                    }
                    else
                    {
                        _continue = false;
                        serialPort.Close();
                        cmdConnecter.Text = "Connecter";
                    }
                }

                private void e_serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
                {
                    int length = serialPort.BytesToRead;
                    tBLength.Text = length.ToString();
                }

                public  void Read()
                {
                    int length = 0;
                    while (_continue)
                    {
                        try
                        {
                            int  length_1 = serialPort.BytesToRead;
                            if (length_1 > length)
                            {
                                // string message = _serialPort.ReadLine();
                                length = length_1;
                                //tBLength.Text = length.ToString();
                                TexteArg tA = new TexteArg(length.ToString());
                               // onEventDataReceived(tA, tBLength);
                            }
                        }
                        catch (TimeoutException) { }
                    }
                }

                void m_appelerDelegateInterThread(AfficherHandle aH, TexteArg tA, TextBox tB)// (d_delegateInterThread v_delegate)
                {
                    if (this.InvokeRequired)
                    {
                        var v_d = new AfficherHandle(aH);
                        try { Invoke(v_d); }
                        catch { }
                    }
                    else
                    {
                        aH(null, tA,tB);
                    }
                }


             /*   void setTextSafeBtn_Click(		object sender, 			EventArgs e)
                {
                    this.demoThread = 
                        new Thread(new ThreadStart(this.ThreadProcSafe));

                    this.demoThread.Start();
                }

                // This method is executed on the worker thread and makes// a thread-safe call on the TextBox control.private
                void ThreadProcSafe()
                {
                    this.SetText("This text was set safely.");
                }

                void SetText(string text)
                {
                    // InvokeRequired required compares the thread ID of the// calling thread to the thread ID of the creating thread.// If these threads are different, it returns true.if (this.textBox1.InvokeRequired)
                    {	
                        SetTextCallback d = new SetTextCallback(SetText);
                        this.Invoke(d, newobject[] { text });
                    }
                    else
                    {
                        this.textBox1.Text = text;
                    }
                }

                void onEventDataReceived(TexteArg text, TextBox tB)
                {
                    if (EventDataReceived != null)
                    {
                        EventDataReceived(new object(), text, tB);
                    }
                }

                private void button1_Click(object sender, EventArgs e){
                    String nom="alfano.dat";
        BinaryReader br = null; 
        BinaryWriter bw = null; 
        FileStream fs = null; 
        //Ecriture d'octets dans le fichier
        bw = new BinaryWriter(File.Create(nom));


     
                    while (serialPort.BytesToRead > 0)
                    {
                        listBytes.Add(serialPort.ReadByte());
                    }
                    int i = 0;
                    string result = "";
                    string car = "";
                    foreach (int bit in listBytes)
                    {
                        bw.Write((byte)bit);
                        car = String.Format("{0:X} ", bit);
                        if (car.Trim().Length == 1) { car = "0" + car; }
                        result += car;
                        i++;
                        if (i > 16)
                        {
                            i = 0;
                            lbChronos.Items.Add(result);
                            result = "";
                        }
                    }
                    bw.Flush();
                    bw.Close();
                   // fs.Close();
                }
            }

            public class TexteArg : EventArgs
            {
                public readonly String _texte;

                public TexteArg(string text)
                {
                    _texte = text;
                }

            }

            class Program
            {
                static void Main(string[] args)
                {
                    Curator curator = new Curator();
                    curator.PropertyChanged += curator_PropertyChanged;
                    curator.CommissionGiven += curator_CommissionGiven;

                    curator.GiveCommission(150);

                    Console.ReadLine();
                }

                static void curator_PropertyChanged(object sender, PropertyChangedEventArgs e)
                {
                    Console.WriteLine("EVENT: PropertyChanged ({0})", e.PropertyName);
                }

                static void curator_CommissionGiven(object sender, CommissionGivenEventArgs e)
                {
                    Console.WriteLine("EVENT: CommissionGiven ({0})", e.Amount);
                }
            }

            public class Curator : INotifyPropertyChanged
            {
                private int _balance = 0;

                public event EventHandler<CommissionGivenEventArgs> CommissionGiven;
                public event PropertyChangedEventHandler PropertyChanged;

                public void RaisePropertyChanged(string propertyName)
                {
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }

                public int Balance
                {
                    get { return _balance; }
                    private set
                    {
                        _balance = value;
                        RaisePropertyChanged("Balance");
                    }
                }

                public void GiveCommission(int amount)
                {
                    this.Balance += amount;

                    if (CommissionGiven != null)
                        CommissionGiven(this, new CommissionGivenEventArgs(amount));
                }
            }

            public class CommissionGivenEventArgs : EventArgs
            {
                public CommissionGivenEventArgs(int amount)
                {
                    this.Amount = amount;
                }

                public int Amount { get; private set; }
            }*/
    }
}
