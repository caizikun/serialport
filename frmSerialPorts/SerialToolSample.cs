using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Modbus.Data;
using Modbus.Device;
using Modbus.Utility;

namespace frmSerialPorts
{
    public partial class SerialToolSample : Form
    {
        public SerialPort comm;
        public StringBuilder builder = new StringBuilder();

        public long received_count = 0;//received count
        public long send_count = 0;
        private bool _listening = false;
        private bool _closing = false;

        public SerialToolSample()
        {
            InitializeComponent();
        }

        private void SerialToolSample_Load(object sender, EventArgs e)
        {
            initData();
        }
        public void initData()
        {
            api.commSetSerialPara(cbox0PortName, SerialPort.GetPortNames(), 2);
            api.commSetSerialPara<SerialPortBaudRates>(cbox1BaudRate, "9600", true);
            api.commSetSerialPara<SerialPortDatabits>(cbox2DataBits, "8", true);
            api.commSetSerialPara<Parity>(cbox3Parity, 0, false);
            api.commSetSerialPara<StopBits>(cbox4StopBits, 1, false);
          
            //comm.NewLine = "/r/n";
            //comm.RtsEnable = true;
            //even
            comm.DataReceived += new SerialDataReceivedEventHandler(comm_DataReceived);
        }

        void comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (_closing)
            {
                return;
            }
            try
            {
                _listening = true;

                int n = comm.BytesToRead;

                byte[] buf = new byte[n];

                received_count += n;

                comm.Read(buf, 0, n);

                builder.Clear();

                this.Invoke((EventHandler)(delegate
                {
                    if (chk0HexView.Checked)
                    {
                        //依次的拼接出16进制字符串
                        foreach (byte b in buf)
                        {
                            builder.Append(b.ToString("X2") + " ");
                        }
                    }
                    else
                    {//直接按Ascii规则转换成字符串。
                        builder.Append(Encoding.ASCII.GetString(buf));
                    }

                    this.txt0Rece.AppendText(builder.ToString());

                    //change the rece count
                    lbl2Get.Text = "Get:" + received_count.ToString();
                }));
            }
            catch (Exception ex)
            {
                _listening = false;
                MessageBox.Show(ex.Message);
                //throw;
            }
            finally
            {
                _listening = false;
            }


            //throw new NotImplementedException();
        }

        private void btn0Open_Click(object sender, EventArgs e)
        {
            if (comm==null)
            {
                //init
                comm = new SerialPort();
            }

            if (comm.IsOpen)
            {
                _closing = true;
                while (_listening)
                {
                    Application.DoEvents();
                }
                comm.Close();
                lblmsg0.Text = "未连接";
                _closing = false;
            }
            else
            {
                comm.PortName = cbox0PortName.Text;
                comm.BaudRate = int.Parse(cbox1BaudRate.Text);

                try
                {
                    comm.Open();
                    lblmsg0.Text = "已连接";
                }
                catch (Exception ex)
                {
                    comm = new SerialPort();
                    MessageBox.Show(ex.Message);

                    // throw;
                }
            }
            btn0Open.Text = comm.IsOpen ? "Close" : "Open";
            btn2Send.Enabled = comm.IsOpen;
        }

        private void chk1AutoNewLine_CheckedChanged(object sender, EventArgs e)
        {
            txt0Rece.WordWrap = chk1AutoNewLine.Checked;
        }

        private void btn2Send_Click(object sender, EventArgs e)
        {
            int n = 0;

            //16进制发送

            if (chk2Hex.Checked)
            {
                try
                {
                    MatchCollection mc = Regex.Matches(txt1Send.Text, @"(?i)[/da-f]{2}");
                    List<byte> buf = new List<byte>();

                    foreach (Match item in mc)
                    {
                        buf.Add(byte.Parse(item.Value, System.Globalization.NumberStyles.HexNumber));
                    }

                    comm.Write(buf.ToArray(), 0, buf.Count);
                    n = buf.Count;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //throw;
                }

            }
            else
            {
                if (comm.IsOpen)
                {
                    if (chk3Auto.Checked)
                    {
                        comm.WriteLine(txt1Send.Text);
                        n = txt0Rece.Text.Length + 2;
                    }
                    else
                    {
                        comm.Write(txt1Send.Text);
                        n = txt1Send.Text.Length;
                    }
                }
                else
                {
                    lblmsg0.Text = "未连接";
                    return;
                }

            }
            send_count += n;
            lbl2Send.Text = "Send:" + send_count.ToString();

        }

        private void btn1Reset_Click(object sender, EventArgs e)
        {
            send_count = received_count = 0;
            lbl2Get.Text = "Get:0";
            lbl2Send.Text = "Send:0";
            txt0Rece.Text = "";
            txt1Send.Text = "";
        }

        private void btn5GetSalve_Click(object sender, EventArgs e)
        {
            while (_closing)
            {
                Application.DoEvents();
            }
            using (SerialPort port = new SerialPort(cbox0PortName.Text))
            {
                _closing = true;
                btn5GetSalve.Enabled = false;
                port.BaudRate = int.Parse(cbox1BaudRate.Text);
                port.DataBits = int.Parse(cbox2DataBits.Text);
                port.Parity = (Parity)Enum.Parse(typeof(Parity), cbox3Parity.Text);
                port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cbox4StopBits.Text);


                try
                {
                    port.Open();

                    master = ModbusSerialMaster.CreateRtu(port);
                    byte slaveId = 1;
                    ushort startAddress = 0;
                    ushort numRegisters = 10;

                    //read ten registers;
                    // ushort[]  registers =   master.ReadHoldingRegisters(slaveId, startAddress, numRegisters);

                    var registers = master.ReadHoldingRegisters(slaveId, startAddress, numRegisters);
                    for (int i = 0; i < numRegisters; i++)
                    {
                        var data = "Register " + startAddress + i + "=" + registers[i] + "\r\n";
                        this.Invoke((EventHandler)(delegate
                        {
                            txt0Rece.Multiline = true;
                            txt0Rece.WordWrap = true;
                            txt0Rece.AppendText(data);
                        }));
                    }
                }
                catch (Exception ex)
                {
                    _closing = false;
                    MessageBox.Show(ex.Message);

                    if (comm!=null)
                    {
                        btn0Open_Click(sender, e);
                    }
                    //throw;
                }
                finally
                {
                    btn5GetSalve.Enabled = true;
                    _closing = false;
                }
            }



        }


        public IModbusSerialMaster master { get; set; }
    }
}
