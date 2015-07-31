using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;

namespace frmSerialPorts
{
    /// <summary>
    /// 串口数据位列表(5,6,7,8)
    /// </summary>
    public enum SerialPortDatabits : int
    {
        FiveBits = 5,
        SixBits = 6,
        SeventBits = 7,
        EightBits = 8
    }
    public enum SerialPortBaudRates : int
    {
        BaudRate_75 = 75,
        BaudRate_110 = 110,
        BaudRate_150 = 150,
        BaudRate_300 = 300,
        BaudRate_600 = 600,
        BaudRate_1200 = 1200,
        BaudRate_2400 = 2400,
        BaudRate_4800 = 4800,
        BaudRate_9600 = 9600,
        BaudRate_14400 = 14400,
        BaudRate_19200 = 19200,
        BaudRate_28800 = 28800,
        BaudRate_38400 = 38400,
        BaudRate_56000 = 56000,
        BaudRate_57600 = 57600,
        BaudRate_115200 = 115200,
        BaudRate_128000 = 128000,
        BaudRate_230400 = 230400,
        BaudRate_256000 = 256000
    }
    public class api
    {
        public Form1 _frm;
        public static byte EndByte = 0x23;//string End = "#"; 
        /// <summary>
        /// 使用枚举构造
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="name"></param>
        /// <param name="baud"></param>
        /// <param name="par"></param>
        /// <param name="dbits"></param>
        /// <param name="sbits"></param>
        public api(Form1 frm, string name, SerialPortBaudRates baud,
             Parity par, SerialPortDatabits dbits, StopBits sbits)
        {
            _portName = name;
            _baudRate = baud;
            _parity = par;
            _dataBits = dbits;
            _stopBits = sbits;
            _frm = frm;

            _frm.serialPort1.DataReceived += new SerialDataReceivedEventHandler(_serial_DataReceived);
            _frm.serialPort1.ErrorReceived += new SerialErrorReceivedEventHandler(_serial_Error);
        }

        /// <summary>
        /// 使用字符构造
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="name"></param>
        /// <param name="baud"></param>
        /// <param name="par"></param>
        /// <param name="dbits"></param>
        /// <param name="sbits"></param>
        public api(Form1 frm, string name, string baud,
             string par, string dbits, string sbits)
        {
            _portName = name;
            _baudRate = (SerialPortBaudRates)Enum.Parse(typeof(SerialPortBaudRates), baud);
            _parity = (Parity)Enum.Parse(typeof(Parity), par);
            _dataBits = (SerialPortDatabits)Enum.Parse(typeof(SerialPortDatabits), dbits);
            _stopBits = (StopBits)Enum.Parse(typeof(StopBits), sbits);
            _frm = frm;

            _frm.serialPort1.DataReceived += new SerialDataReceivedEventHandler(_serial_DataReceived);
            _frm.serialPort1.ErrorReceived += new SerialErrorReceivedEventHandler(_serial_Error);
        }

        public event DataReceivedEventHandler DataReceived;
        public event SerialErrorReceivedEventHandler Error;

        void _serial_Error(object sender, SerialErrorReceivedEventArgs e)
        {
            if (Error != null)
            {
                Error(sender, e);
            }
        }

        void _serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //禁止接收事件时直接退出 
            // if (ReceiveEventFlag) return;

            #region 根据结束字节来判断是否全部获取完成
            List<byte> _byteData = new List<byte>();
            bool found = false;//是否检测到结束符号 
            while (_frm.serialPort1.BytesToRead > 0 || !found)
            {
                byte[] readBuffer = new byte[_frm.serialPort1.ReadBufferSize + 1];
                int count = _frm.serialPort1.Read(readBuffer, 0, _frm.serialPort1.ReadBufferSize);
                for (int i = 0; i < count; i++)
                {
                    _byteData.Add(readBuffer[i]);

                    if (readBuffer[i] == api.EndByte)
                    {
                        found = true;
                    }
                }
            }
            #endregion

            //字符转换 
            string readString =

System.Text.Encoding.Default.GetString(_byteData.ToArray(), 0, _byteData.Count);

            //触发整条记录的处理 
            if (DataReceived != null)
            {
                DataReceived(new DataReceivedEventArgs(readString));
            }
        }


        public bool IsOpen
        {
            get
            {
                return _frm.serialPort1.IsOpen;
            }
        }
        public void OpenPort()
        {
            if (_frm.serialPort1.IsOpen)
            {
                _frm.serialPort1.Close();
            }
            _frm.serialPort1.PortName = _portName;
            _frm.serialPort1.BaudRate = (int)_baudRate;
            _frm.serialPort1.Parity = _parity;
            _frm.serialPort1.DataBits = (int)_dataBits;
            _frm.serialPort1.StopBits = _stopBits;

            _frm.serialPort1.Open();

        }
        public void ClosePort()
        {
            if (_frm.serialPort1.IsOpen)
            {
                _frm.serialPort1.Close();
            }
        }
        public void DisCardBuffer()
        {
            _frm.serialPort1.DiscardInBuffer();
            _frm.serialPort1.DiscardOutBuffer();
        }
        public void WriteData(string msg)
        {
            if (!(_frm.serialPort1.IsOpen))
            {
                _frm.serialPort1.Open();
                _frm.serialPort1.Write(msg);
            }
        }
        public void WriteData(byte[] msg)
        {
            if (!(_frm.serialPort1.IsOpen))
            {
                _frm.serialPort1.Open();
                _frm.serialPort1.Write(msg, 0, msg.Length);
            }
        }

        public void WriteData(byte[] msg, int offset, int count)
        {
            if (!(_frm.serialPort1.IsOpen))
            {
                _frm.serialPort1.Open();
                _frm.serialPort1.Write(msg, offset, count);
            }
        }
        public static void commSetSerialPara<T>(ComboBox obj, object indexOrText, bool isMenuint)
        {
            try
            {
                obj.Items.Clear();
                foreach (T item in Enum.GetValues(typeof(T)))
                {
                    if (isMenuint)
                    {
                        obj.Items.Add(Convert.ToInt32(item).ToString());

                    }
                    else
                    {
                        obj.Items.Add(item.ToString());
                    }

                }
                var tmptype = indexOrText.GetType();
                if (tmptype.ToString().Equals("System.Int32"))
                {
                    obj.SelectedIndex = Convert.ToInt32(indexOrText);
                }
                else if (tmptype.ToString().Equals("System.String"))
                {
                    obj.SelectedText = indexOrText.ToString();
                }
                //MessageBox.Show(tmptype.ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        public static void commSetSerialPara(ComboBox obj, string[] strs, int index)
        {
            obj.Items.Clear();
            foreach (string str in strs)
            {
                obj.Items.Add(str);
            }
            obj.SelectedIndex = index;
        }
        /// <summary>
        /// 设置串口号
        /// </summary>
        /// <param name="obj"></param>
        public static void SetPortNameValues(ComboBox obj, int index)
        {
            obj.Items.Clear();
            foreach (string str in SerialPort.GetPortNames())
            {
                obj.Items.Add(str);
            }
            obj.SelectedIndex = index;
        }
        /// <summary>
        /// 设置波特率
        /// </summary>
        /// <param name="obj"></param>
        public static void SetBaudRateValues(ComboBox obj, string str)
        {
            obj.Items.Clear();
            foreach (SerialPortBaudRates rate in Enum.GetValues(typeof(SerialPortBaudRates)))
            {
                obj.Items.Add(((int)rate).ToString());
            }
            obj.SelectedText = str;
        }
        /// <summary>
        /// 设置数据位
        /// </summary>
        /// <param name="obj"></param>
        public static void SetDataBitsValues(ComboBox obj, string str)
        {
            obj.Items.Clear();
            foreach (SerialPortDatabits databit in Enum.GetValues(typeof(SerialPortDatabits)))
            {
                obj.Items.Add(((int)databit).ToString());
            }
            obj.SelectedText = str;
        }
        ///  <summary>
        /// 设置校验位列表 
        ///  </summary>
        public static void SetParityValues(ComboBox obj, int index)
        {
            obj.Items.Clear();
            foreach (string str in Enum.GetNames(typeof(Parity)))
            {
                obj.Items.Add(str);
            }
            obj.SelectedIndex = index;
        }

        ///  <summary>
        /// 设置停止位 
        ///  </summary>
        public static void SetStopBitValues(ComboBox obj, int index)
        {
            obj.Items.Clear();
            foreach (string str in Enum.GetNames(typeof(StopBits)))
            {
                obj.Items.Add(str);
            }
            obj.SelectedIndex = index;

        }

        public StopBits _stopBits { get; set; }

        public SerialPortDatabits _dataBits { get; set; }

        public Parity _parity { get; set; }

        public SerialPortBaudRates _baudRate { get; set; }

        public string _portName { get; set; }
    }
}
public class DataReceivedEventArgs : EventArgs
{
    public string DataReceived;
    public DataReceivedEventArgs(string m_DataReceived)
    {
        this.DataReceived = m_DataReceived;
    }
}

public delegate void DataReceivedEventHandler(DataReceivedEventArgs e);