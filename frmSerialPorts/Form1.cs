using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace frmSerialPorts
{

    public partial class Form1 : Form
    {
        public static bool isOpened = false;
        public api _serial;
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
            //绑定端口号
            api.SetPortNameValues(cbox0PortName, 0);

            //波特率
            api.SetBaudRateValues(cbox1BaudRate, "115200");
            //数据位
            api.SetDataBitsValues(cbox2DataBits, "8");
            //校验位
            api.SetParityValues(cbox3Parity, 0);

            //停止位
            api.SetStopBitValues(cbox4StopBits, 1);

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

                com.Write(txt0Send.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // throw;
            }


        }



        public SerialPort com { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            if (com != null)
            {
                com.Close();
            }
        }
    }
}
