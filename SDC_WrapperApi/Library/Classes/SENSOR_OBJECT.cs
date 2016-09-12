/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using Library;
using System.Linq.Expressions;
using System.Configuration;

using System.Data;
using System.Data.SqlClient;
using CodeScience.EeziTracker.Controller;
*/

using System;
using System.IO.Ports;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;



namespace Library
{
    public class SENSOR_OBJECT: IDisposable
    {
        #region Enumerations
        public enum EBaudRate
        {
            Baud4800, //= "4800",
            Baud9600, //= "9600",
            Baud19200, //= "19200",
            Baud38400, //= "38400",
            Baud57600, //= "57600",
            Baud115200, //= "115200"
            Baud250000           
        };
        
       
        #endregion

        #region Properties
        
        private string _BaudRate { get; set; }

        private string _COMport { get; set; }

        private Library.PacketStates.PacketState _SendPacketState { get; set; }
        #endregion

        #region Public Events
        //Returns if Error
        public delegate void ERROR_RESPONSE_OBJECT(ERROR_DATA_RESPONSE oTEMP_RESPONSE_OBJECT);
        public event ERROR_RESPONSE_OBJECT ERROR_RESPONSE_RECEIVED;
        //Return with Raw Data for testing
        public delegate void TEMP_RESPONSE_DELEGATE(byte[] Temp_Response_Array);
        public event TEMP_RESPONSE_DELEGATE TEMP_RESPONSE_ARRAY;
        
        
        // Returns Download EEPROM Status
        public delegate void EEPROM_RESPONSE_DELEGATE(TransactionStatusClass.TransactionValues STATUS);
        public event EEPROM_RESPONSE_DELEGATE EEPROM_RESPONSE_RECEIVED;
        //Returns Clear EEPROM Status
        public delegate void CLR_EEPROM_RESPONSE_DELEGATE(TransactionStatusClass.TransactionValues STATUS);
        public event CLR_EEPROM_RESPONSE_DELEGATE CLR_EEPROM_RESPONSE_RECEIVED;
        //Returns Set RTC Status
        public delegate void SET_RTC_RESPONSE_DELEGATE(TransactionStatusClass.TransactionValues STATUS);
        public event SET_RTC_RESPONSE_DELEGATE SET_RTC_RESPONSE_RECEIVED;
        //Returns Get RTC STATUS
        public delegate void GET_RTC_RESPONSE_DELEGATE(TransactionStatusClass.TransactionValues STATUS);
        public event SET_RTC_RESPONSE_DELEGATE GET_RTC_RESPONSE_RECEIVED;
        //Returns TIMEOUT ERROR
        public delegate void TIMEOUT_RESPONSE_DELEGATE();
        public event TIMEOUT_RESPONSE_DELEGATE TIMEOUT_RESPONSE_RECEIVED;

        #endregion

        #region Classes
        //private TemperatureDecoderClass mDecoder;
        private ERROR_DATA_RESPONSE TempDataResponse;
        private Library.CommsDecoder decoder;
        #endregion

        #region Constructor
        public SENSOR_OBJECT(EBaudRate BaudRate, string COM_port)
        {
            try
            {
                _BaudRate = ReturnStringBaudrate(BaudRate);
                _COMport = COM_port.Replace(" ", "").ToUpper();

                string[] ports = SerialPort.GetPortNames();
                
                
                if (!ports.Contains(_COMport))
                    throw new Exception("Com Port Not Available");
            }
            catch (Exception Ex)
            {
                Function_CallError_Received(Ex.Message);
            }
        }
        #endregion

        #region Send Data

        public void Send_Clear_EEPROM()
        {
            try
            {
                _SendPacketState = Library.PacketStates.PacketState.CLEAR_EEPROM;
                Send_Command_Data("!A");
            }
            catch
            {                
                throw;
            }            
        }

        public void Send_Download_EEPROM()
        {
            try
            {
                _SendPacketState = Library.PacketStates.PacketState.DOWNLOAD_EEPROM;
                Send_Command_Data("!D");
            }
            catch (Exception)
            {                
                throw;
            }            
        }

        public void Set_RTC()
        {
            try
            {
                _SendPacketState = Library.PacketStates.PacketState.WRITE_RTC;
                string YearMonthDay = DateTime.Now.ToString("yyMMdd");
                string DayoftheWeek = GetDayOfWeek();
                string HourMinute = DateTime.Now.ToString("HHmm");
                // System.Diagnostics.Debug.WriteLine(DateTime.Now.);
                Send_Command_Data("!C" + YearMonthDay + DayoftheWeek + HourMinute);
            }
            catch (Exception)
            {                
                throw;
            }
            
        }

       
        public void Get_RTC()
        {
            try
            {
                _SendPacketState = Library.PacketStates.PacketState.READ_RTC;
                Send_Command_Data("!B");
            }
            catch (Exception)
            {                
                throw;
            }
            
        }

        //Generic Serial Send Data Command
        private void Send_Command_Data(string Data)
        {
            try
            {
                decoder = new CommsDecoder(_BaudRate, _COMport, _SendPacketState);
                //Generic Byte Array
                decoder.TempSensor_ByteArray_Received += decoder_TempSensor_ByteArray_Received;
                //Error Events
                decoder.Timeout_Received += new CommsDecoder.Timeout_EventHandler(decoder_Timeout_Received);
                //EEPROM Data Received Event
                decoder.EEPROM_Data_Received += decoder_EEPROM_Data_Received;
                //Clear EEPROM Event Received
                decoder.Clear_EEPROM_Response_REceived += decoder_Clear_EEPROM_Response_REceived;
                //Download/Read RTC Event Received
                decoder.RTC_Data_Received += decoder_RTC_Data_Received;
                //Write RTC Event Received
                decoder.RTC_Write_Response_Received += decoder_RTC_Write_Response_Received;

                // Send Data Command
                decoder.SEND_TEMPSENSOR_COMMAND(Data);
            }
            catch
            {
                //Function_CallError_Received(Ex.Message);
                throw;
            }
            
        }

        #endregion

        #region DECODER EVENTS RECEIVED

        void decoder_RTC_Write_Response_Received(TransactionStatusClass STATUS)
        {
            //decoderDisposeCollect();

            Function_Return_SET_RTC_STATUS(STATUS.TransactionStatus);
        }

        void decoder_RTC_Data_Received(RTCSerialDataClass RTC_DATA, TransactionStatusClass STATUS)
        {
            Function_Return_GET_RTC_STATUS(STATUS.TransactionStatus);
           // decoderDisposeCollect();
            //Not implemented
        }

        void decoder_Clear_EEPROM_Response_REceived(TransactionStatusClass STATUS)
        {
            //decoderDisposeCollect();

            Function_Return_CLR_EEPROM_STATUS(STATUS.TransactionStatus);            
        }

        void decoder_EEPROM_Data_Received(EEPROMSerialDataClass EEPROM_DATA, TransactionStatusClass STATUS)
        {            
            //Ensure All data lengths are the Same
            //If it is not -> Then serial data is invalid.
            if (STATUS.TransactionStatus != TransactionStatusClass.TransactionValues.FAILED)
            {                
                try
                {
                    int arraysize = EEPROM_DATA.BaseMAC.Count;

                    string controllerkey = ConfigurationManager.AppSettings["ConrollerKey"];
                    CodeScience.EeziTracker.Controller.Api.Controller EeziTrackerApi = new CodeScience.EeziTracker.Controller.Api.Controller("ConnectionString");
                    for (int i = 0; i < arraysize; i++)
                    {
                        System.Diagnostics.Debug.WriteLine(MAC2GUID(EEPROM_DATA.BaseMAC[i]));
                        string guid = MAC2GUID(EEPROM_DATA.BaseMAC[i]);
                        if (guid != "")
                        {
                            EeziTrackerApi.InsertDeviceData(guid, EEPROM_DATA.ConvertedTemp[i], controllerkey, EEPROM_DATA.ConvertedDateTime[i]);
                        }
                    }                    
                }
                catch
                {
                    Function_Return_EEPROM_STATUS(TransactionStatusClass.TransactionValues.FAILED);
                }

                    try
                    {
                        decoder.ClearEEPROM();
                    }
                    catch
                    {
                        Function_Return_CLR_EEPROM_STATUS(TransactionStatusClass.TransactionValues.FAILED);
                    }

                Function_Return_EEPROM_STATUS(TransactionStatusClass.TransactionValues.SUCCESS);
            }
            else
            {
                Function_Return_EEPROM_STATUS(TransactionStatusClass.TransactionValues.FAILED);
            }           
        }               

        void decoder_TempSensor_ByteArray_Received(byte[] BytesReceived)
        {
            if (TEMP_RESPONSE_ARRAY != null)
            {
                TEMP_RESPONSE_ARRAY(BytesReceived);
            }
        }

        #endregion

        #region GET GUID FROM GUID MAPPING TABLE
        private string ReturnGUID(int sDEVICE_ID)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                // Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Work\TempSensor\SDC_WrapperApi\Library\eezitracker.mdf;Integrated Security=True
                //ConfigurationManager.AppSettings["ConnectionString"]
                conn.Open();
                string table = "DEVICE_ID";
                string column = "DEVICE_ID";
                string deviceid = sDEVICE_ID.ToString();
                string query = "SELECT * FROM " + table + " WHERE " + column + " = " + deviceid;

                SqlCommand command = new SqlCommand(query, conn);

                SqlDataReader myReader = command.ExecuteReader();

                string guidvalue = "";
                while (myReader.Read())
                {
                    // System.Diagnostics.Debug.WriteLine(myReader["DEVICE_ID"].ToString());
                    // System.Diagnostics.Debug.WriteLine(myReader["DEVICE_ID_GUID"].ToString());
                    guidvalue = myReader["DEVICE_ID_GUID"].ToString();
                }
                return guidvalue;
            }
        }

        private string MAC2GUID(char[] cMAC)
        {
            //30dd879c - ee2f - 11db - 8314 - 0800200c9a66
            string sMAC = new string(cMAC);
            string guidvalue = "00000000-0000-0000-0000-"+ sMAC;
            return guidvalue;
        }
        #endregion

        #region EVENT TRIGGERS FUNCTIONS

        void decoder_Timeout_Received()
        {
            if (TEMP_RESPONSE_ARRAY != null)
            {
                TempDataResponse = new Library.ERROR_DATA_RESPONSE();
                TempDataResponse.ParamName1 = "Error";
                TempDataResponse.ParamValue1 = "Timeout";
                TEMP_RESPONSE_ARRAY(Encoding.ASCII.GetBytes("Timeout Error"));
            }

            if (TIMEOUT_RESPONSE_RECEIVED != null)
            {
                TIMEOUT_RESPONSE_RECEIVED();
            }
        }

        void Function_CallError_Received(string Message)
        {
            if (ERROR_RESPONSE_RECEIVED != null)
            {
                TempDataResponse = new ERROR_DATA_RESPONSE();
                TempDataResponse.ParamName1 = "Error";
                TempDataResponse.ParamValue1 = Message;
                ERROR_RESPONSE_RECEIVED(TempDataResponse);
            }
        }

        void Function_Return_EEPROM_STATUS(TransactionStatusClass.TransactionValues Status)
        {
            if (EEPROM_RESPONSE_RECEIVED != null)
            {
                EEPROM_RESPONSE_RECEIVED(Status);
            }
        }

        void Function_Return_CLR_EEPROM_STATUS(TransactionStatusClass.TransactionValues Status)
        {
            if (CLR_EEPROM_RESPONSE_RECEIVED != null)
            {
                CLR_EEPROM_RESPONSE_RECEIVED(Status);
            }
        }

        void Function_Return_SET_RTC_STATUS(TransactionStatusClass.TransactionValues Status)
        {
            if (SET_RTC_RESPONSE_RECEIVED != null)
            {
                SET_RTC_RESPONSE_RECEIVED(Status);
            }
        }

        void Function_Return_GET_RTC_STATUS(TransactionStatusClass.TransactionValues Status)
        {
            if (GET_RTC_RESPONSE_RECEIVED != null)
            {
                GET_RTC_RESPONSE_RECEIVED(Status);
            }
        }

        #endregion

        #region General function - RETURN BAUD STRINGS / GET DAY OF WEEK
        private string ReturnStringBaudrate(EBaudRate Baud)
        {
            switch (Baud)
            {
                case EBaudRate.Baud250000:
                {
                    return "250000";
                }
                case EBaudRate.Baud115200:
                {
                    return "115200";
                }
                case EBaudRate.Baud57600:
                {
                    return "57600";
                }
                case EBaudRate.Baud38400:
                {
                    return "38400";
                }
                case EBaudRate.Baud19200:
                {
                    return "19200";
                }
                case EBaudRate.Baud9600:
                {
                    return "9600";
                }
                case EBaudRate.Baud4800:
                {
                    return "4800";
                }
                default:
                {
                    throw new Exception("Incorrect Baudrate");
                }
            }
        }

        private string GetDayOfWeek()
        {
            string DayoftheWeek = DateTime.Now.DayOfWeek.ToString();
            string DayofWeekInt;

            switch (DayoftheWeek)
            {
                case "Monday":
                    {
                        DayofWeekInt = "01";
                        break;
                    }
                case "Tuesday":
                    {
                        DayofWeekInt = "02";
                        break;
                    }
                case "Wednesday":
                    {
                        DayofWeekInt = "03";
                        break;
                    }
                case "Thursday":
                    {
                        DayofWeekInt = "04";
                        break;
                    }
                case "Friday":
                    {
                        DayofWeekInt = "05";
                        break;
                    }
                case "Saturday":
                    {
                        DayofWeekInt = "06";
                        break;
                    }
                case "Sunday":
                    {
                        DayofWeekInt = "07";
                        break;
                    }
                default:
                    {
                        DayofWeekInt = "00";
                        break;
                    }
            }

            return DayofWeekInt;
        }

        #endregion       

        #region DISPOSALS
        public void decoderDisposeCollect()
        {
            if (decoder != null)
            {
                //decoder.SerialCloseDisposeCollect();
                decoder.Dispose();
                decoder = null;
            }
            GC.Collect();
        }
    
        public void Dispose()
        {
            if (_BaudRate != null)
                _BaudRate = null;
            if (_COMport != null)
                _COMport = null;
            if (decoder != null)
            {
                decoder.Dispose();
                decoder = null;
            }
        }

        #endregion
    }
}
