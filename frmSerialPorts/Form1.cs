using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace frmSerialPorts
{

    public partial class Form1 : Form
    {
        public static bool isOpened = false;
        public api _serial;
        Thread _readThread;
        bool _keepReading;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            ////绑定端口号
            //api.SetPortNameValues(cbox0PortName, 0);
            ////波特率
            //api.SetBaudRateValues(cbox1BaudRate, "115200");
            ////数据位
            //api.SetDataBitsValues(cbox2DataBits, "8");
            ////校验位
            //api.SetParityValues(cbox3Parity, 0);
            ////停止位
            //api.SetStopBitValues(cbox4StopBits, 1);

            api.commSetSerialPara(cbox0PortName,SerialPort.GetPortNames(), 0);
            api.commSetSerialPara<SerialPortBaudRates>(cbox1BaudRate, "115200",true);
            api.commSetSerialPara<SerialPortDatabits>(cbox2DataBits, "8", true);
            api.commSetSerialPara<Parity>(cbox3Parity, 0, false);
            api.commSetSerialPara<StopBits>(cbox4StopBits, 1, false);

            this.btnSend.Enabled = isOpened;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (_serial == null)
                {
                    try
                    {
                        string portname = this.cbox0PortName.Text;
                        SerialPortBaudRates rate = (SerialPortBaudRates)Enum.Parse(typeof(SerialPortBaudRates), this.cbox1BaudRate.Text);
                        Parity parity = (Parity)Enum.Parse(typeof(Parity), cbox3Parity.Text);
                        SerialPortDatabits dataBits = (SerialPortDatabits)Enum.Parse(typeof(SerialPortDatabits), cbox2DataBits.Text);
                        StopBits stopBits = (StopBits)Enum.Parse(typeof(StopBits), cbox4StopBits.Text);

                        _serial = new api(this, portname, this.cbox1BaudRate.Text, cbox3Parity.Text, cbox2DataBits.Text, cbox4StopBits.Text);

                        _serial.DataReceived += new DataReceivedEventHandler(_serial_DataReceived);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        _serial = null;
                        throw;
                    }

                    if (!isOpened)
                    {
                        _serial.OpenPort();
                        btnStop.Text = "断开";
                    }
                    else
                    {
                        _serial.ClosePort();
                        _serial = null;

                        btnStop.Text = "连接";
                    }

                    isOpened = !isOpened;
                    this.btnSend.Enabled = isOpened;

                    this.lblmsg0.Text = isOpened ? "已连接" : "未连接";

                }
            }
            catch (Exception ex)
            {
                this.lblmsg0.Text = ex.Message;
                MessageBox.Show(ex.Message);

            }
        }

        void _serial_DataReceived(DataReceivedEventArgs e)
        {
            //throw new NotImplementedException();
            txt1Rece.Invoke(new MethodInvoker(delegate
            {
                this.txt1Rece.AppendText(e.DataReceived + Environment.NewLine);
            }));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            _serial.WriteData(txt0Send.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (com == null)
                {
                    com = new SerialPort();
                    com.DataReceived += new SerialDataReceivedEventHandler(com_DataReceived);
                }

                com.BaudRate = (int)((SerialPortBaudRates)Enum.Parse(typeof(SerialPortBaudRates), cbox1BaudRate.Text));
                com.Parity = (Parity)Enum.Parse(typeof(Parity), cbox3Parity.Text);
                com.DataBits = (int)((SerialPortDatabits)Enum.Parse(typeof(SerialPortDatabits), cbox2DataBits.Text));
                com.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cbox4StopBits.Text);

                if (!com.IsOpen)
                {
                    com.PortName = cbox0PortName.Text;
                    com.Open();
                }
                else
                {
                    com.Close();
                    com.PortName = cbox0PortName.Text;
                    com.Open();
                }
                //if (_readThread == null)
                //{
                //    _keepReading = true;
                //    _readThread = new Thread(readprot);
                //    _readThread.Start();
                //}

                com.Write(txt0Send.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // throw;
            }


        }

        void com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //throw new NotImplementedException();
            txt1Rece.Invoke(new MethodInvoker(delegate
            {
                this.txt1Rece.AppendText(com.ReadExisting() + Environment.NewLine);
            }));
        }



        public SerialPort com { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            if (com != null)
            {
                com.Close();
            }
        }
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }
        private void ThreadFunction(string str)
        {
            //throw new NotImplementedException();
            txt1Rece.Invoke(new MethodInvoker(delegate
            {
                this.txt1Rece.AppendText(str + Environment.NewLine);
            }));
        }
        public void readprot()
        {
            while (_keepReading)
            {
                if (com.IsOpen)
                {
                    byte[] readbuffer = new byte[com.ReadBufferSize + 1];
                    try
                    {
                        int count = com.Read(readbuffer, 0, com.ReadBufferSize);
                        string serialIn = System.Text.Encoding.ASCII.GetString(readbuffer, 0, count);
                        if (count != 0)
                        {
                            //byteToHexStr(readbuffer);
                            ThreadFunction(byteToHexStr(readbuffer));
                        }

                    }
                    catch (TimeoutException ex)
                    {
                        MessageBox.Show(ex.Message);
                        //throw;
                    }
                }
                else
                {
                    TimeSpan waitTime = new TimeSpan(0, 0, 0, 0, 50);
                    Thread.Sleep(waitTime);
                }
            }

        }
    }
}
