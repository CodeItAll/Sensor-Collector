/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
*/


//using System.Threading;

using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.Threading;

namespace Library
{   
    internal class SerialPortClass : IDisposable
    {
        #region Data Received Delegate
        
        /// <summary>
        /// Serial Data Received Event
        /// </summary>
        /// <param name="SerialData"> Array of Received Serial byte values </param>
        public delegate void ReceivedSerialEventHandler(byte[] SerialData);
        public event ReceivedSerialEventHandler SerialDataReceived;
        #endregion


        // Store Comport Variable settings
        #region Manager Properties
        //User Set
        private string _baudRate = string.Empty;
        private string _portName = string.Empty;
        // Always Set
        private int _dataBits = 8;
        private StopBits _stopBits = StopBits.One;
        private Parity _parity = Parity.None;
        private Handshake _handshake = Handshake.None;

        public SerialPort comPort; // = new SerialPort();

        public string Baudrate
        {
            get {return _baudRate;}
            set {_baudRate = value;}
        }

        public string PortName
        {
            get {return _portName;}
            set {_portName = value;}
        }

        

    #endregion
                
        #region Constructor
        public SerialPortClass()
        {
            comPort = new SerialPort();
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
                  
        }

        // Data Received Delegate Trigger
        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //Thread.Sleep(2000);
                //byte[] ReadSerialData = new byte[comPort.BytesToRead];
                
                //string TotalSerialData = "";
                //string stringData = "";
                
                List<byte> ListByte = new List<byte>();
                byte[] ReadSerialData;
                
                do
                {
                    int numOfBytes = comPort.BytesToRead;
                    ReadSerialData = new byte[numOfBytes];
                    comPort.Read(ReadSerialData, 0, numOfBytes);
                    ListByte.AddRange(ReadSerialData);
                    //stringData = Encoding.UTF8.GetString(ReadSerialData, 0, numOfBytes);
                    //TotalSerialData = TotalSerialData + stringData;
                    PauseForMilliSeconds(40);
                    
                } while (comPort.BytesToRead > 0);


                //do
                //{
                //    Byte ReadSerialData1;
                //    ReadSerialData1 = (byte)comPort.ReadByte();
                //    ListByte.Add(ReadSerialData1);
                //} while (comPort.BytesToRead > 0);


                if (ListByte[ListByte.Count - 2] == 0x0d)
                {
                    if (ListByte[ListByte.Count - 1] == 0x0a)
                    {
                        Console.WriteLine("True");
                        WriteEOT();
                    
                    } 
                }

                ReadSerialData = new byte[ListByte.Count];

                ReadSerialData = ListByte.ToArray();
                //do
                //{
                    //int numOfBytes = comPort.BytesToRead;
                    //ReadSerialData = new byte[numOfBytes];
                    //stringData = comPort.ReadTo("\r\n");
                    ////stringData = Encoding.UTF8.GetString(ReadSerialData, 0, numOfBytes);
                    //TotalSerialData = TotalSerialData + stringData;
                    //PauseForMilliSeconds(200);

                //} while (comPort.BytesToRead > 0);

                //byte[] ReadSerialData = new byte[comPort.BytesToRead];
                //comPort.Read(ReadSerialData, 0, ReadSerialData.Length);

                if (SerialDataReceived != null)
                {
                    SerialDataReceived((ReadSerialData));
                }
            }
            catch //(Exception ex)
            {
                throw;
            }
            
        }

        /*
        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //Thread.Sleep(2000);
                byte[] ReadSerialData = new byte[comPort.BytesToRead];
                comPort.Read(ReadSerialData, 0, ReadSerialData.Length);

                if (SerialDataReceived != null)
                {
                    SerialDataReceived(ReadSerialData);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
         * */
        #endregion

        public static DateTime PauseForMilliSeconds(int MilliSecondsToPauseFor)
        {
            System.DateTime ThisMoment = System.DateTime.Now;
            System.TimeSpan duration = new System.TimeSpan(0, 0, 0, 0, MilliSecondsToPauseFor);
            System.DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                //  System.Windows.Forms.Application.DoEvents()
                ThisMoment = System.DateTime.Now;
            }

            return System.DateTime.Now;
        }

        public void WriteData (byte[] msg)
        {
            try
            {
                if (comPort.IsOpen == true)
                {
                    comPort.DiscardInBuffer();
                    comPort.DiscardOutBuffer();
                    comPort.Write(msg, 0, msg.Length);                    
                }             
            }
            catch
            {
                throw;
            }

        }

        public void WriteEOT()
        {
            try
            {
                if (comPort.IsOpen == true)
                {
                    comPort.DiscardInBuffer();
                    comPort.DiscardOutBuffer();
                    //byte returnbyte = 4;
                    List<byte> list = new List<byte>();
                    //EOT
                    list.Add(4);
                    
                    //Dash
                    list.Add(226);

                    //Hashtag
                    //list.Add(35);

                    //ACK
                    list.Add(6);
                    
                    // !A
                    //list.Add(33);
                    //list.Add(65);
                    byte[] bytearr = new byte[list.Count];
                    bytearr = list.ToArray();
                    //byte[] bytearr = new byte[1];
                    //bytearr = Encoding.UTF8.GetBytes("!A");
                    //bytearr = BitConverter.GetBytes(returnbyte);
                    comPort.Write(bytearr, 0, bytearr.Length);
                }
            }
            catch //(Exception ex)
            {
                throw;
            }

        }

        public void WriteCLREEPROM()
        {
            try
            {
                comPort.DataReceived -= new SerialDataReceivedEventHandler(comPort_DataReceived);

                if (comPort.IsOpen == true)
                {
                    comPort.DiscardInBuffer();
                    comPort.DiscardOutBuffer();
                    //byte returnbyte = 4;
                    List<byte> list = new List<byte>();


                    // !A
                    list.Add(33);
                    list.Add(65);
                    byte[] bytearr = new byte[list.Count];
                    bytearr = list.ToArray();
                    //byte[] bytearr = new byte[1];
                    //bytearr = Encoding.UTF8.GetBytes("!A");
                    //bytearr = BitConverter.GetBytes(returnbyte);
                    comPort.Write(bytearr, 0, bytearr.Length);
                }
            }
            catch
            {
                throw;
            }

        }

        public bool OpenPort()
        {
            //Check if the port is already open
            //if it is then close it
            try
            {
                if (comPort.IsOpen == true)
                {
                    comPort.Close();
                    PauseForMilliSeconds(200);
                }

                //Set Variables
                comPort.BaudRate = int.Parse(_baudRate);
                comPort.DataBits = _dataBits;
                comPort.StopBits = _stopBits;
                comPort.Parity = _parity;
                comPort.PortName = _portName;
                comPort.Handshake = _handshake;
                comPort.ReadTimeout = 10000;
                comPort.WriteTimeout = 5000;
                comPort.ReadBufferSize = 65536;
                comPort.WriteBufferSize = 65536;
                comPort.ReceivedBytesThreshold = 1;
                comPort.DtrEnable = false;
                comPort.RtsEnable = false;
                //comPort.Encoding = System.Text.Encoding.GetEncoding(1252);

                //Open Port
                comPort.Open();

                //Display Message
                // I need a method to return message to console view
                
#if DEBUG
                // System.Diagnostics.Debug.WriteLine(_portName + " opened at " + DateTime.Now + "\n");
#endif
                return true;
            }
            catch (Exception ex)
            {
                 System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }

        }

        public bool OpenPort(int ReceivedBytesThreshold)
        {
            //Check if the port is already open
            //if it is then close it
            try
            {
                if (comPort.IsOpen == true)
                {
                    comPort.Close();
                    comPort.Dispose();
                    PauseForMilliSeconds(200);
                }

                //Set Variables
                comPort.BaudRate = int.Parse(_baudRate);
                comPort.DataBits = _dataBits;
                comPort.StopBits = _stopBits;
                comPort.Parity = _parity;
                comPort.PortName = _portName;
                comPort.Handshake = _handshake;
                comPort.ReadTimeout = 10000;
                comPort.WriteTimeout = 5000;
                comPort.ReadBufferSize = 65536;
                comPort.WriteBufferSize = 65536;
                comPort.ReceivedBytesThreshold = ReceivedBytesThreshold;
                comPort.DtrEnable = false;
                comPort.RtsEnable = false;
                //comPort.Encoding = System.Text.Encoding.GetEncoding(1252);

                //Open Port
                comPort.Open();
                
                System.Diagnostics.Debug.WriteLine(_portName + " opened at " + DateTime.Now + "\n");

                return true;
            }
            catch
            {
                throw;
            }

        }

        public bool ClosePort()
        {
            try
            {
                Thread.Sleep(100);
                //comPort.DataReceived -= new SerialDataReceivedEventHandler(comPort_DataReceived);
                if (comPort.IsOpen)
                {
                    this.comPort.DiscardInBuffer();
                    //this.comPort.Close();
                    this.comPort.Dispose();
                }
                this.Dispose();
                return false; // Is port connected = false
            }
            catch
            {
                //Could not close ports
                return true; // is port connected = true
            }
        }
             
        public void Dispose()
        {
            if (comPort != null)
            {
                //comPort.DiscardInBuffer();
                comPort.Dispose();
                comPort = null;
            }
        }

        public bool OpenPortWithRetry()
        {
            //http://stackoverflow.com/questions/7219653/why-is-access-to-com-port-denied
            //due to a bug in the SerialPort code, the serial port needs time to dispose if we used this recently and then closed
            //therefore the "open" could fail, so put in a loop trying for a few times

            comPort.BaudRate = int.Parse(_baudRate);
            comPort.DataBits = _dataBits;
            comPort.StopBits = _stopBits;
            comPort.Parity = _parity;
            comPort.PortName = _portName;
            comPort.Handshake = _handshake;
            comPort.ReadTimeout = 10000;
            comPort.WriteTimeout = 5000;
            comPort.ReadBufferSize = 65536;
            comPort.WriteBufferSize = 65536;
            comPort.ReceivedBytesThreshold = 1;
            comPort.DtrEnable = false;
            comPort.RtsEnable = false;
            
            int sleepCount = 0;
            while (!TryOpenPort())
            {
                System.Threading.Thread.Sleep(100);
                sleepCount += 1;
                System.Diagnostics.Debug.Print(sleepCount.ToString());
                if (sleepCount > 100) //5 seconds should be heaps !!!
                {
                    throw new Exception(String.Format("Failed to open USB com port {0}", comPort.PortName));
                }
            }
            return true;
        }
        private bool TryOpenPort()
        {
            if (!comPort.IsOpen)
            {
                try
                {
                    comPort.Open();
                    return true;
                }
                catch (UnauthorizedAccessException)
                {
                    comPort.Close();
                    return false;
                }
                catch
                {
                    throw;
                }

            }
            return true;
        }

    }
}
