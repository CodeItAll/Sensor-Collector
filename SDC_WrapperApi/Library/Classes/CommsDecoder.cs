/*using System;   
using System.Collections.Generic;
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
using System.Linq;
using System.Runtime.InteropServices;
*/
//using System.Threading;

using System;
using System.Text;
using System.Linq;
using System.IO;



namespace Library
{
    internal class CommsDecoder : IDisposable
    {
        private Library.SerialPortClass _SerialInstance;
                
        private Library.PacketStates.PacketState CurrentState;
        //private int WaitCounter = 0;


        //Delegate Data Received Events
        #region DELEGATES

        #region TIMEOUT EVENT HANDLER
        public delegate void Timeout_EventHandler();
        public event Timeout_EventHandler Timeout_Received;
        #endregion

        #region EEPROM EVENT HANDLER
        //EEPROM Temperature Data with Time        
        public delegate void Dowload_EEPROM_EventHandler(EEPROMSerialDataClass EEPROM_DATA, TransactionStatusClass STATUS);
        public event Dowload_EEPROM_EventHandler EEPROM_Data_Received;

        public delegate void Write_Clear_EEPROM_EventHandler(TransactionStatusClass STATUS);
        public event Write_RTC_EventHandler Clear_EEPROM_Response_REceived;
        #endregion

        #region RTC EVENT HANDLER
        //Real Time Clock Data
        public delegate void Download_RTC_EventHandler(RTCSerialDataClass RTC_DATA, TransactionStatusClass STATUS);
        public event Download_RTC_EventHandler RTC_Data_Received;

        public delegate void Write_RTC_EventHandler(TransactionStatusClass STATUS);
        public event Write_RTC_EventHandler RTC_Write_Response_Received;
        #endregion

        #region GENERIC EVENT HANDLER
        // Generic Bytes for display and Testing purposes
        public delegate void GENERIC_BYTES_RECEIVED(byte[] BytesReceived);
        public event GENERIC_BYTES_RECEIVED TempSensor_ByteArray_Received;
        #endregion
        #endregion
        
        #region Timer
        private System.Timers.Timer timerClock;
        #endregion

        #region properties
        private string _BaudRate { get; set; }

        private string _COMport { get; set; }

        
        #endregion

        #region Constructor

        public CommsDecoder(string BaudRate, string COMport, Library.PacketStates.PacketState SendPacketState)
        {
            //Set Communication Properties
            _BaudRate = BaudRate;
            _COMport = COMport;
            //Set Current Communication States
            CurrentState = SendPacketState;
            //Initialise timers
            timerClock = new System.Timers.Timer();        
        }

        #endregion

        #region Send Commands

        public void SEND_TEMPSENSOR_COMMAND(string Data)
        {
            _SerialInstance = new SerialPortClass();
            _SerialInstance.Baudrate = _BaudRate;
            _SerialInstance.PortName = _COMport;

            try
            {
                if (_SerialInstance.OpenPortWithRetry())
                {
                    _SerialInstance.SerialDataReceived += new SerialPortClass.ReceivedSerialEventHandler(_SerialInstance_SerialDataReceived);

                    byte[] bytearr = Encoding.UTF8.GetBytes(Data);
                    _SerialInstance.WriteData(bytearr);

                    InitializeTimer();
                }
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Debug.WriteLine(Ex);
                throw;
            }            
        }

        public void ClearEEPROM()
        {
            //CLEAR EEPROM
            CurrentState = PacketStates.PacketState.DOWNLOAD_EEPROM;
            _SerialInstance.WriteCLREEPROM();
        }
        
        #endregion

        #region Data Received Event
        /// <summary>
        /// Serial Data Received Event Handler
        /// </summary>
        /// <param name="SerialData"> Array of Received Serial byte values </param>
        void _SerialInstance_SerialDataReceived(byte[] SerialData)
        {
            try
            {
                DisableTimer();
             
                if (SerialData.Length >= 1)
                {
                    switch (CurrentState)
                    {
                        case Library.PacketStates.PacketState.CLEAR_EEPROM:
                            {
                                //SerialCloseDisposeCollect();

                                TransactionStatusClass cCompleted = new TransactionStatusClass();                                

                                //Should only receive 2 bytes CR & LF
                                if ((SerialData.Length == 2) && (SerialData.Contains((byte)0x0d) && SerialData.Contains((byte)0x0a)))
                                {
                                    cCompleted.TransactionStatus = TransactionStatusClass.TransactionValues.SUCCESS;
                                }
                                else
                                {
                                    cCompleted.TransactionStatus = TransactionStatusClass.TransactionValues.FAILED;
                                }

                                //Activate Delegate Event
                                if (TempSensor_ByteArray_Received != null)
                                {
                                    TempSensor_ByteArray_Received(SerialData);
                                }

                                if (Clear_EEPROM_Response_REceived != null)
                                {
                                    Clear_EEPROM_Response_REceived(cCompleted);
                                }
                                break;
                            }
                        case Library.PacketStates.PacketState.DOWNLOAD_EEPROM:
                            {                           
                                 //Data Class Instantiation
                                TransactionStatusClass cCompleted = new TransactionStatusClass();
                                 EEPROMSerialDataClass Data = new EEPROMSerialDataClass();                                                                                               

                                //Start Decoding - Check that array contains LineFeed and Carriage Returm
                                if (SerialData.Contains((byte)0x0d) && SerialData.Contains((byte)0x0a)) 
                                {
                                     //Remove Carriage Returm and Line Feed
                                    byte[] newArray = SerialData.Where(b => (b != 0x0d)&(b != 0x0a)).ToArray();

                                    if (newArray.Length > 2)
                                    {
                                        //Should do a mod Test to ensure that the right number of bytes are here.
                                        Stream stream = new MemoryStream(newArray);
                                        BinaryReader reader = new BinaryReader(stream);

                                        BigEndianReader BigEndianReader = new BigEndianReader(reader);

                                        UInt16 mask = 0x03FF;
                                        UInt16 BatteryVoltage = BigEndianReader.ReadUInt16();
                                        Data.ControllerBatteryVoltage = (UInt16)(BatteryVoltage & mask);
                                        Data.ConvertedBatteryVoltage = Convert.ToDecimal(Data.ControllerBatteryVoltage) * 3.3M * 3 / 1023;
                                        byte seperationbyte;

                                        while (BigEndianReader.BaseStream.Position != BigEndianReader.BaseStream.Length)
                                        {
                                            byte bID = 0;
                                            byte bTemp = 0;
                                            string sDate = String.Empty;
                                            try
                                            {
                                                bID = BigEndianReader.ReadByte();
                                                Data.DeviceID.Add(bID);

                                                bTemp = BigEndianReader.ReadByte();
                                                Data.DeviceTemp.Add(bTemp);

                                                sDate = Encoding.UTF8.GetString(BigEndianReader.ReadBytes(10));
                                                Data.DeviceDateTime.Add(sDate);
                                                seperationbyte = BigEndianReader.ReadByte();
                                            }
                                            catch (Exception Ex)
                                            {
                                                // Catch decode Exception - this will be triggered if binary reader gets to the end of the stream before
                                                // identifying the CRLF
                                                cCompleted.TransactionStatus = TransactionStatusClass.TransactionValues.FAILED;
                                                 System.Diagnostics.Debug.WriteLine(Ex.ToString());
                                            }

                                            Data.ConvertedTemp.Add(((decimal)(((Convert.ToDecimal(bTemp) * 3.3M / 1023) - 0.45M) * 100)));

                                            Data.dd.Add(sDate.ToCharArray(0, 2));
                                            Data.MM.Add(sDate.ToCharArray(2, 2));
                                            Data.yy.Add(sDate.ToCharArray(4, 2));
                                            Data.HH.Add(sDate.ToCharArray(6, 2));
                                            Data.mm.Add(sDate.ToCharArray(8, 2));

                                            string syy = new string(sDate.ToCharArray(4, 2));
                                            string syyyy = DateTime.Now.ToString("yyyy");
                                            string sMM = new string(sDate.ToCharArray(2, 2));
                                            string sdd = new string(sDate.ToCharArray(0, 2));
                                            string sHH = new string(sDate.ToCharArray(6, 2));
                                            string smm = new string(sDate.ToCharArray(8, 2));

                                            int yy = int.Parse(syyyy.Remove(2, 2) + syy);
                                            int MM = int.Parse(sMM);
                                            int dd = int.Parse(sdd);
                                            int HH = int.Parse(sHH);
                                            int mm = int.Parse(smm);
                                            //DateTime test = DateTime.Now.ToString("yyyy");
                                            DateTime ConvertedTime = new DateTime(yy, MM, dd, HH, mm, 0);

                                            Data.ConvertedDateTime.Add(ConvertedTime);
                                        }

                                        if ((Data.DeviceTemp.Count == Data.DeviceID.Count) && (Data.DeviceDateTime.Count == Data.DeviceID.Count))
                                        {
                                            cCompleted.TransactionStatus = TransactionStatusClass.TransactionValues.SUCCESS;
                                            
                                            System.Diagnostics.Debug.WriteLine("Class: CommsDecoder, Line 248: Success - Received Download EEPROM Event");
                                            // Close Com Port
                                            //_SerialInstance.WriteData(Encoding.UTF8.GetBytes("!A"));
                                            //////////////////////////////////////
                                            
                                            
                                            System.Diagnostics.Debug.WriteLine("Class: CommsDecoder, Line 256: Success - Send EOT");
                                        }
                                        else
                                        {
                                            cCompleted.TransactionStatus = TransactionStatusClass.TransactionValues.FAILED;
                                            System.Diagnostics.Debug.WriteLine("Class: CommsDecoder, Line 258: Failed Count not equal");
                                        }
                                    }
                                    else
                                    {
                                        cCompleted.TransactionStatus = TransactionStatusClass.TransactionValues.SUCCESS;
                                        System.Diagnostics.Debug.WriteLine("Class: CommsDecoder, Line 263: Success But Download EEPROM Packet <2");
                                    }
                                }
                                else
                                {
                                    cCompleted.TransactionStatus = TransactionStatusClass.TransactionValues.FAILED;
                                    System.Diagnostics.Debug.WriteLine("Class: CommsDecoder, Line 270: Download EEPROM Failed - No CR + LF");
                                }

                                //CloseDisposeCollect();

                                System.Diagnostics.Debug.WriteLine("Class: CommsDecoder, Line 175: Send GC Collect");
                                                                
                                //Activate Delegate Event
                                if (TempSensor_ByteArray_Received != null)
                                {
                                    TempSensor_ByteArray_Received(SerialData);
                                }

                                if (EEPROM_Data_Received != null)
                                {
                                    EEPROM_Data_Received(Data,cCompleted);  
                                }

                                break;
                            }
                        case Library.PacketStates.PacketState.READ_RTC:
                            {
                                // Close Com Port
                                // SerialCloseDisposeCollect();

                                TransactionStatusClass cCompleted = new TransactionStatusClass();
                                Library.RTCSerialDataClass sDate = new RTCSerialDataClass();

                                //Start Decoding - Check that array contains LineFeed and Carriage Returm
                                //if (SerialData.Contains((byte)13) && SerialData.Contains((byte)10))
                                if (SerialData.Contains((byte)0x0d) && SerialData.Contains((byte)0x0a))
                                {
                                    //Remove Carriage Returm and Line Feed
                                    byte[] newArray = SerialData.Where(b => (b != 0x0d) & (b != 0x0a)).ToArray();
                                    
                                    // Format must be 12 characters else incorrect
                                    if (newArray.Length == 12)
                                    {
                                        Stream stream = new MemoryStream(newArray);
                                        BinaryReader reader = new BinaryReader(stream);
                                        
                                        sDate.yy = reader.ReadChars(2);
                                        sDate.MM = reader.ReadChars(2);
                                        sDate.dd = reader.ReadChars(2);
                                        sDate.dd = reader.ReadChars(2);
                                        sDate.ww = reader.ReadChars(2);
                                        sDate.HH = reader.ReadChars(2);
                                        sDate.mm = reader.ReadChars(2);

                                        cCompleted.TransactionStatus = TransactionStatusClass.TransactionValues.SUCCESS;                                      
                                    }
                                    else
                                    {
                                        sDate = null;
                                        cCompleted.TransactionStatus = TransactionStatusClass.TransactionValues.FAILED;   
                                    }                                    
                                    
                                    //Activate Delegate Event
                                    if (TempSensor_ByteArray_Received != null)
                                    {
                                        TempSensor_ByteArray_Received(newArray);
                                    }

                                    //Activate RTC Data Event
                                    if (RTC_Data_Received != null)
                                    {
                                        RTC_Data_Received(sDate, cCompleted);
                                    }
                                }
                                else
                                { 
                                    //Do what when it does not contain CR & LF
                                    sDate = null;
                                    cCompleted.TransactionStatus = TransactionStatusClass.TransactionValues.FAILED;
                                    // Close Com Port
                                    //_SerialInstance.ClosePort();

                                    //Send Data that was not correct to front end for testing
                                    if (TempSensor_ByteArray_Received != null)
                                    {
                                        TempSensor_ByteArray_Received(SerialData);
                                    }

                                    //Activate RTC Data Event
                                    if (RTC_Data_Received != null)
                                    {
                                        RTC_Data_Received(sDate, cCompleted);
                                    }
                                    
                                }
                                break;
                            }
                        case Library.PacketStates.PacketState.WRITE_RTC:
                            {
                                //CloseDisposeCollect();

                                TransactionStatusClass cCompleted = new TransactionStatusClass();

                                //Should only receive 2 bytes CR & LF
                                if ((SerialData.Length == 2) && (SerialData.Contains((byte)0x0d) && SerialData.Contains((byte)0x0a)) )
                                {
                                    cCompleted.TransactionStatus = TransactionStatusClass.TransactionValues.SUCCESS;
                                }
                                else
                                {
                                    cCompleted.TransactionStatus = TransactionStatusClass.TransactionValues.FAILED;
                                }

                                //Activate Delegate Event
                                if (TempSensor_ByteArray_Received != null)
                                {
                                    TempSensor_ByteArray_Received(SerialData);
                                }

                                if (RTC_Write_Response_Received != null)
                                {
                                    RTC_Write_Response_Received(cCompleted);
                                }
                                break;
                            }
                        default:
                            {
                                //_SerialInstance.ClosePort();
                                break;
                            }
                    }
                }
                // Else If DataLength <=0 
                // No data was received
                else
                {
                    //_SerialInstance.ClosePort();
                }
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Debug.WriteLine(Ex);
                throw;
            }

        }
        #endregion

        #region Initialise Timer
        private void InitializeTimer()
        {
            this.timerClock.Elapsed += new System.Timers.ElapsedEventHandler(OnTimer);
            this.timerClock.Interval = 40000;
            this.timerClock.Enabled = true;
        }

        private void DisableTimer()
        {
            this.timerClock.Elapsed -= new System.Timers.ElapsedEventHandler(OnTimer);
            this.timerClock.Enabled = false;
        }

        void OnTimer(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Timeout_Received != null)
            {
                DisableTimer();
                Timeout_Received();
            }
        }
        #endregion

        #region DISPOSALS
        /*
        public void SerialCloseDisposeCollect()
        {
            if (_SerialInstance != null)
            {
                _SerialInstance.ClosePort();
                _SerialInstance = null;
            }
            GC.Collect();
        }
         */

        
        public void Dispose()
        {
            if (_SerialInstance != null)
            {
                _SerialInstance.Dispose();
                _SerialInstance = null;
            }

            if (timerClock != null)
            {
                timerClock = null;
            }

            if (_BaudRate != null)
            {
                _BaudRate = null;
            }

            if (_COMport != null)
            {
                _COMport = null;
            }

        }

        #endregion
    }
}
