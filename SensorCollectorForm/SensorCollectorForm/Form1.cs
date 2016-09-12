
/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Used for Serial Port Enumeration
using System.IO.Ports;
using CodeScience.EeziTracker.Controller;
//using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Threading; 

using Library;
using System.Configuration;
 * */

using System;
using System.Drawing;
using System.Windows.Forms;
using Library;
using System.IO.Ports;
using System.Configuration;
using System.Linq;
using System.Data.SqlClient;
using System.Threading;
using System.Net;

namespace SensorCollectorForm
{
    public partial class Form1 : Form
    {
        string SelectedPort { get; set; }
        bool StartedUpdateTimer { get; set; }

        //Counter
        int TimerCount = 0;
        int ServerTimerCount = 0;

        SENSOR_OBJECT sense_o;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception Ex)
            {
                //DisplayData(Ex.Message);
                System.Diagnostics.Debug.WriteLine(Ex.Message);
                
            }            
        }

        public Form1()
        {
            InitializeComponent();
            GetSerialPorts();
            StartedUpdateTimer = false;
        }

        #region GET SERIAL PORT NAMES
        private void GetSerialPorts()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new MethodInvoker(() => GetSerialPorts()));
                }
                else
                {

                    string[] ports = SerialPort.GetPortNames();

                    if (ports.Length > 0)
                    {
                        comboBox_serialPorts.Items.AddRange(ports);
                        comboBox_serialPorts.SelectedItem = ports[0];
                        SelectedPort = ports[0];
                    }
                    else
                    {
                        SelectedPort = "";
                    }
                }
            }
            catch (Exception Ex)
            {
                DisplayData(Ex.Message + "\r\n");
                System.Diagnostics.Debug.WriteLine(Ex.Message);
            }

        }
        #endregion

        #region DEBUG BUTTONS CLICKS
        private void btn_clear_eeprom_Click(object sender, EventArgs e)
        {
            // !A
            /*
            try
            {
                GetSerialPorts();
                sense_o = new SENSOR_OBJECT(SENSOR_OBJECT.EBaudRate.Baud9600, SelectedPort);
                sense_o.CLR_EEPROM_RESPONSE_RECEIVED += sense_o_CLR_EEPROM_RESPONSE_RECEIVED;
                sense_o.Send_Clear_EEPROM();
            }
            catch (Exception Ex)
            {
                //NEW
                if (sense_o != null)
                {
                    sense_o.Dispose();
                    GC.Collect();
                }

                DisplayData(Ex.Message);
                System.Diagnostics.Debug.WriteLine(Ex.Message);
            }
            */
            Clear_EEPROM();
        }

        private void btn_read_rtc_Click(object sender, EventArgs e)
        {
            // !B
            try
            {
                GetSerialPorts();
                if (SelectedPort != "")
                {
                    sense_o = new SENSOR_OBJECT(SENSOR_OBJECT.EBaudRate.Baud250000, SelectedPort);
                    sense_o.TEMP_RESPONSE_ARRAY += sense_o_TEMP_RESPONSE_ARRAY;
                    sense_o.GET_RTC_RESPONSE_RECEIVED += Sense_o_GET_RTC_RESPONSE_RECEIVED;
                    sense_o.TIMEOUT_RESPONSE_RECEIVED += Sense_o_TIMEOUT_RESPONSE_RECEIVED;

                    sense_o.Get_RTC();
                }
            }
            catch (Exception Ex)
            {
                //NEW
                if (sense_o != null)
                {
                    sense_o.Dispose();
                    GC.Collect();
                }

                DisplayData(Ex.Message);
                System.Diagnostics.Debug.WriteLine(Ex.Message);
            }
        }

       

        private void btn_write_RTC_Click(object sender, EventArgs e)
        {
            // !C
            Set_RTC();
            /*
            try
            {
                GetSerialPorts();
                if (SelectedPort != "")
                {
                    sense_o = new SENSOR_OBJECT(SENSOR_OBJECT.EBaudRate.Baud9600, SelectedPort);
                    sense_o.TEMP_RESPONSE_ARRAY += sense_o_TEMP_RESPONSE_ARRAY;
                    sense_o.Set_RTC();
                }
            }
            catch (Exception Ex)
            {
                //NEW
                if (sense_o != null)
                {
                    sense_o.Dispose();
                    GC.Collect();
                }

                DisplayData(Ex.Message);
                System.Diagnostics.Debug.WriteLine(Ex.Message);
            }
            */
        }

        private void btn_dnwld_eeprom_Click(object sender, EventArgs e)
        {
            //!D
            try
            {
                Download_EEPROM();
            }
            catch (Exception Ex)
            {
                //NEW
                if (sense_o != null)
                {
                    sense_o.Dispose();
                    GC.Collect();
                }

                DisplayData(Ex.Message);
                System.Diagnostics.Debug.WriteLine(Ex.Message);
            }
        }

        private void btn_OpenCom_Click(object sender, EventArgs e)
        {
            if (comboBox_serialPorts.SelectedItem != null)
            {
                SelectedPort = comboBox_serialPorts.SelectedItem.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (CheckForInternetConnection())
            //{
                UpdateToServer();
                System.Diagnostics.Debug.WriteLine("EEPROM Data Update to Server");
            //
            System.Diagnostics.Debug.WriteLine("EEProm Data Received - before sending clear eeprom command");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string controllerkey = ConfigurationManager.AppSettings["ConrollerKey"];
            CodeScience.EeziTracker.Controller.Api.Controller API = new CodeScience.EeziTracker.Controller.Api.Controller("ConnectionString");
            //DateTime ConvertedTime = new DateTime(2015, 11, 2, 15, 54, 0);
            /*
            string syy = "15";
            string syyyy = DateTime.Now.ToString("yyyy");
            string sMM = "11";
            string sdd = "02";
            string sHH = "19";
            string smm = "16";

            int yy = int.Parse(syyyy.Remove(2, 2) + syy);
            int MM = int.Parse(sMM);
            int dd = int.Parse(sdd);
            int HH = int.Parse(sHH);
            int mm = int.Parse(smm);*/
            //DateTime test = DateTime.Now.ToString("yyyy");
            //DateTime ConvertedTime = new DateTime(yy, MM, dd, HH, mm, 0);
            DateTime ConvertedTime = new DateTime(
                int.Parse(DateTime.Now.ToString("yyyy")), 
                int.Parse(DateTime.Now.ToString("MM")), 
                int.Parse(DateTime.Now.ToString("dd")), 
                int.Parse(DateTime.Now.ToString("HH")), 
                int.Parse(DateTime.Now.ToString("mm")), 
                0);
            // C
            API.InsertDeviceData("1635E944-9486-4CAA-A2F2-D1D3B8913503", (decimal)22, controllerkey, ConvertedTime);
            // A
            //API.InsertDeviceData("778f91e0-48df-4429-b8a2-b5f86b0e5905", (decimal)22, controllerkey, ConvertedTime);
            
            
            /*string testdevicekey = ConfigurationManager.AppSettings["TestDeviceKey"];
            decimal temp = (decimal)12.23;

            string controllerkey = ConfigurationManager.AppSettings["ConrollerKey"];
            //CodeScience.EeziTracker.Controller.Api.Controller EeziTrackerApi = new CodeScience.EeziTracker.Controller.Api.Controller("ConnectionString");
            CodeScience.EeziTracker.Controller.Api.Controller EeziTrackerApi = new CodeScience.EeziTracker.Controller.Api.Controller("ConnectionString");
            //EeziTrackerApi.InsertDeviceData(testdevicekey,temp, controllerkey, );
             */ 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string test = ReturnGUID(66);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            bool status = CheckForInternetConnection();
            DisplayData("Can Connect to Google : " + status.ToString() + System.Environment.NewLine);
            System.Diagnostics.Debug.WriteLine("Can Connect to Google : " + status.ToString());
        }

        #endregion

        #region EVENT TRIGGER FUNCTIONS

        private void Sense_o_TIMEOUT_RESPONSE_RECEIVED()
        {
            if (sense_o != null)
            {
                sense_o.Dispose();
                GC.Collect();
            }
        }

        void sense_o_TEMP_RESPONSE_ARRAY(byte[] Temp_Response_Array)
        {
            DisplayData(BitConverter.ToString(Temp_Response_Array) + '\n');
            DisplayData(System.Text.Encoding.ASCII.GetString(Temp_Response_Array) + '\n');

            //sense_o.Dispose();
            //GC.Collect();
        }

        void sense_o_EEPROM_RESPONSE_RECEIVED(TransactionStatusClass.TransactionValues STATUS)
        {
            System.Diagnostics.Debug.WriteLine("EEPROM Data Received");
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => sense_o_EEPROM_RESPONSE_RECEIVED(STATUS)));
            }
            else
            {
                string Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                UpdateListView(1, STATUS.ToString(), Time, 0);

                if (STATUS == TransactionStatusClass.TransactionValues.SUCCESS)
                {
                    System.Diagnostics.Debug.WriteLine("EEPROM Data Received Transaction was a success");
                    // Going To remove this for to it's own thread
                    //Check4InternetThenUpdateToServer();                                 
                }
            }

            if (sense_o != null)
            {
                sense_o.Dispose();
                GC.Collect();
            }
        }

        void sense_o_CLR_EEPROM_RESPONSE_RECEIVED(TransactionStatusClass.TransactionValues STATUS)
        {
            System.Diagnostics.Debug.WriteLine("Clear EEPROM Response Received");
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => sense_o_CLR_EEPROM_RESPONSE_RECEIVED(STATUS)));
            }
            else
            {
                string Time = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss");
                UpdateListView(2, STATUS.ToString(), Time, 0);
            }

            if (sense_o != null)
            {
                sense_o.Dispose();
                GC.Collect();
            }
        }

        void sense_o_SET_RTC_RESPONSE_RECEIVED(TransactionStatusClass.TransactionValues STATUS)
        {
            System.Diagnostics.Debug.WriteLine("Set RTC Response Received ");

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => sense_o_SET_RTC_RESPONSE_RECEIVED(STATUS)));
            }
            else
            {
                string Time = DateTime.Now.ToString("yyyy-MM-dd-HHmm-ss");
                System.Diagnostics.Debug.WriteLine("sense_o_SET_RTC_RESPONSE_RECEIVED : Time : " + Time);
                UpdateListView(0, STATUS.ToString(), Time, 0);
            }

            if (sense_o != null)
            {
                sense_o.Dispose();
                GC.Collect();
            }
        }

        private void Sense_o_GET_RTC_RESPONSE_RECEIVED(TransactionStatusClass.TransactionValues STATUS)
        {
            System.Diagnostics.Debug.WriteLine("GET RTC Response Received ");

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => Sense_o_GET_RTC_RESPONSE_RECEIVED(STATUS)));
            }
            else
            {
                string Time = DateTime.Now.ToString("yyyy-MM-dd-HHmm-ss");
                System.Diagnostics.Debug.WriteLine("sense_o_GET_RTC_RESPONSE_RECEIVED : Time : " + Time);
                UpdateListView(4, STATUS.ToString(), Time, 0);
            }

            if (sense_o != null)
            {
                sense_o.Dispose();
                GC.Collect();
            }

        }


        #endregion

        #region DISPLAY DATA FUNCTION / RICH TEXTBOX UPDATE

        private void UpdateListView(int Row, string Status, string DateTime, int Count)
        {
            // Row 0 - SET RTC
            // Row 1 - DWNLOAD EEPROM
            // ROW 2 - CLR EEPROM
            // ROW 3 - SEND TO SERVER
            try
            {

                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new MethodInvoker(() => UpdateListView(Row, Status, DateTime, Count)));
                }
                else
                {
                    ListViewItem lvi = MessageListView.Items[Row];
                    lvi.SubItems[0].Text = lvi.SubItems[0].Text;
                    lvi.SubItems[1].Text = Status;
                    lvi.SubItems[2].Text = DateTime;
                    lvi.SubItems[3].Text = Count.ToString();
                }
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Debug.WriteLine(Ex.ToString());
                DisplayData(Ex.ToString());
            }
        }

        public void DisplayData(string msg)
        {      
            try
            {
                richTextBox.BeginInvoke(new EventHandler(delegate
                    {
                        var lines = richTextBox.Lines;
                        try
                        {
                            if (lines.Count() >= 17)
                            {
                                if (lines.Count() > 100)
                                {
                                    richTextBox.Text.Remove(0, msg.Count() + 20);
                                    richTextBox.Lines = lines.Skip(1).ToArray();
                                    richTextBox.AppendText(msg);
                                }
                                else
                                {
                                    richTextBox.Lines = lines.Skip(1).ToArray();
                                    richTextBox.AppendText(msg);
                                }
                            }
                            else
                            {
                                richTextBox.AppendText(msg);
                            }
                        }
                        catch
                        {
                        }
                        richTextBox.ScrollToCaret();

                    }));
            }
            catch (Exception Ex)
            {               
                System.Diagnostics.Debug.WriteLine("Ensure Software is connected to through communication channel \n");
                System.Diagnostics.Debug.WriteLine(Ex.ToString());
                DisplayData(Ex.ToString());
            }        
        }

        #endregion

        #region RETURN GUID FROM SQL DB
        private string ReturnGUID(int sDEVICE_ID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                    conn.Open();
                    string table = "DEVICE_ID";
                    string column = "DEVICE_ID";
                    string deviceid = sDEVICE_ID.ToString();
                    string query = "SELECT * FROM " + table + " WHERE " + column + " = " + deviceid;

                    SqlCommand command = new SqlCommand(query, conn);

                    SqlDataReader myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        //System.Diagnostics.Debug.WriteLine(myReader["DEVICE_ID"].ToString());
                        //System.Diagnostics.Debug.WriteLine(myReader["DEVICE_ID_GUID"].ToString());
                        return myReader["DEVICE_ID_GUID"].ToString();
                    }
                    return null;
                }
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Debug.WriteLine(Ex.ToString());
                DisplayData(Ex.ToString());
                return null;
            }            
        }

        #endregion

        #region UPDATE DATA TO SERVER 
        private void UpdateToServer()
        {
            System.Diagnostics.Debug.WriteLine("Begin Update To server");
            CodeScience.EeziTracker.Controller.Api.Server EeziTrackerApi = new CodeScience.EeziTracker.Controller.Api.Server("ConnectionString");
            string ServiceBaseAddress = ConfigurationManager.AppSettings["ServiceBaseAddress"];
            string Time = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss");
            try
            {
                //Thread UpdateServerThread = new System.Threading.Thread(delegate()
                //{
                    EeziTrackerApi.SendToServer(ServiceBaseAddress);
                    UpdateListView(3, "Updated to Server", Time, 0);
                //});
                //UpdateServerThread.Start();
            }
            catch (Exception ex)
            {
                DisplayData(ex.ToString() + System.Environment.NewLine);
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                UpdateListView(3, "Failed Update to Server", Time, 0);
            }
            System.Diagnostics.Debug.WriteLine("End Update To server");
        }
        #endregion

        #region CUSTOM FUNCTIONS - CHECK INTERNET
        private void Check4InternetThenUpdateToServer()
        {
            if (CheckForInternetConnection())
            {
                UpdateToServer();
                System.Diagnostics.Debug.WriteLine("EEPROM Data Update to Server");
            }
            System.Diagnostics.Debug.WriteLine("EEProm Data Received - before sending clear eeprom command");    
        }

        public static bool CheckForInternetConnection()
        {   
            System.Diagnostics.Debug.WriteLine("Begin Check for internet connection");

            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        
        #endregion

        #region CUSTOM FUNCTIONS - SEND COMMANDS
        private void Download_EEPROM()
        {
            //Set objects
            try
            {
                GetSerialPorts();
                if (SelectedPort != "")
                {
                    sense_o = new SENSOR_OBJECT(SENSOR_OBJECT.EBaudRate.Baud250000, SelectedPort);
                    sense_o.TEMP_RESPONSE_ARRAY += sense_o_TEMP_RESPONSE_ARRAY;
                    sense_o.EEPROM_RESPONSE_RECEIVED += sense_o_EEPROM_RESPONSE_RECEIVED;
                    sense_o.CLR_EEPROM_RESPONSE_RECEIVED += sense_o_CLR_EEPROM_RESPONSE_RECEIVED;
                    sense_o.TIMEOUT_RESPONSE_RECEIVED += Sense_o_TIMEOUT_RESPONSE_RECEIVED;

                    sense_o.Send_Download_EEPROM();
                }
                else
                {
                    string Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    UpdateListView(1, "NO COM PORT", Time, 0);
                }
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Debug.WriteLine(Ex.ToString());
                DisplayData(Ex.ToString());

                if (sense_o != null)
                {
                    sense_o.Dispose();
                    GC.Collect();
                }
            }            
        }



        private void Clear_EEPROM()
        {
            try
            {
                GetSerialPorts();
                if (SelectedPort != "")
                {
                    sense_o = new SENSOR_OBJECT(SENSOR_OBJECT.EBaudRate.Baud250000, SelectedPort);
                    sense_o.TEMP_RESPONSE_ARRAY += sense_o_TEMP_RESPONSE_ARRAY;
                    sense_o.CLR_EEPROM_RESPONSE_RECEIVED += sense_o_CLR_EEPROM_RESPONSE_RECEIVED;
                    sense_o.TIMEOUT_RESPONSE_RECEIVED += Sense_o_TIMEOUT_RESPONSE_RECEIVED;

                    sense_o.Send_Clear_EEPROM();
                }
                else
                {
                    string Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    UpdateListView(2, "NO COM PORT", Time, 0);
                }
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Debug.WriteLine(Ex.ToString());
                DisplayData(Ex.ToString());

                if (sense_o != null)
                {
                    sense_o.Dispose();
                    GC.Collect();
                }
            }            
        }

        private void Set_RTC()
        {
            try
            {
                GetSerialPorts();
                if (SelectedPort != "")
                {
                    sense_o = new SENSOR_OBJECT(SENSOR_OBJECT.EBaudRate.Baud250000, SelectedPort);
                    sense_o.SET_RTC_RESPONSE_RECEIVED += sense_o_SET_RTC_RESPONSE_RECEIVED;
                    sense_o.TEMP_RESPONSE_ARRAY += sense_o_TEMP_RESPONSE_ARRAY;
                    sense_o.TIMEOUT_RESPONSE_RECEIVED += Sense_o_TIMEOUT_RESPONSE_RECEIVED;

                    sense_o.Set_RTC();
                }
                else
                {
                    string Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    UpdateListView(0, "NO COM PORT", Time, 0);
                }
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Debug.WriteLine(Ex.ToString());
                DisplayData(Ex.ToString());

                if (sense_o != null)
                {
                    sense_o.Dispose();
                    GC.Collect();
                }
            }
        }

       

        #endregion

        #region Timer Ticks 

        private void timer_Get_EEPROM_Tick(object sender, EventArgs e)
        {
            try
            {
                TimerCount++;
                if (TimerCount == 1)
                {
                    if (StartedUpdateTimer == false)
                    {
                        timer_UpdateToServer.Enabled = true;
                        timer_UpdateToServer.Start();
                        StartedUpdateTimer = true;
                    }
                }
                if (TimerCount == 200)
                {
                    TimerCount = 0;
                    Set_RTC();
                }
                else if (TimerCount % 2 == 0)
                {
                    Thread myThread = new System.Threading.Thread(delegate()
                    {
                        Download_EEPROM(); //Your code here
                    });
                    myThread.Start();
                }
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Debug.WriteLine(Ex.ToString());
                DisplayData(Ex.ToString());

                if (sense_o != null)
                {
                    sense_o.Dispose();
                    GC.Collect();
                }
            }
        }

        private void timer_UpdateToServer_Tick(object sender, EventArgs e)
        {
            ServerTimerCount++;
            if (ServerTimerCount == 1)
            {
                Thread ServerUpdateThread = new System.Threading.Thread(delegate()
                {
                    Check4InternetThenUpdateToServer();
                });
                ServerUpdateThread.Start();
            }
            else  if (TimerCount % 2 == 0)
            {
                Thread ServerUpdateThread = new System.Threading.Thread(delegate()
                {
                    Check4InternetThenUpdateToServer();
                });
                ServerUpdateThread.Start();
            }
        }
        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime ConvertedTime = new DateTime(2000, 01, 0, 00, 00, 0);

        }
    }
}
