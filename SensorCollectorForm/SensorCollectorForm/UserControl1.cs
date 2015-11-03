using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Library;

namespace SensorCollectorForm
{
    public partial class UserControl1: UserControl
    {

        public UserControl1()
        {
            InitializeComponent();
        }

        private void btn_clear_eeprom_Click(object sender, EventArgs e)
        {
            // !A
            SENSOR_OBJECT sense_o = new SENSOR_OBJECT(SENSOR_OBJECT.EBaudRate.Baud9600, "COM1");
            sense_o.TEMP_RESPONSE_RECEIVED += sense_o_TEMP_RESPONSE_RECEIVED;
        }

        void sense_o_TEMP_RESPONSE_RECEIVED(TEMP_DATA_RESPONSE oTEMP_RESPONSE_OBJECT)
        {
            throw new NotImplementedException();
        }

        void sense_o_SDC_RESPONSE_RECEIVED(SDC_DATA_RESPONSE oSDC_RESPONSE_OBJECT)
        {
            throw new NotImplementedException();
        }

        private void btn_read_rtc_Click(object sender, EventArgs e)
        {
            // !B
            SENSOR_OBJECT sense_o = new SENSOR_OBJECT(SENSOR_OBJECT.EBaudRate.Baud9600, "COM1");
            sense_o.TEMP_RESPONSE_RECEIVED += sense_o_TEMP_RESPONSE_RECEIVED;
        }

        private void btn_write_RTC_Click(object sender, EventArgs e)
        {
            // !C
        }

        private void btn_write_fridge_temp_alarm_thresh_Click(object sender, EventArgs e)
        {
            // !E
        }

        private void btn_read_fridge_temp_alarm_thresh_Click(object sender, EventArgs e)
        {
            // !F
        }

        private void btn_read_defrost_cycle_period_Click(object sender, EventArgs e)
        {
            // !P
        }

        private void btn_write_Defrost_cycle_period_Click(object sender, EventArgs e)
        {
            // !M
        }

        private void btn_read_fridge_status_Click(object sender, EventArgs e)
        {
            // !G
        }

        private void btn_clear_fridge_slarm_status_Click(object sender, EventArgs e)
        {
            // !H
        }

        private void btn_read_error_event_status_Click(object sender, EventArgs e)
        {
            // !I
        }

        private void btn_read_bat_voltage_Click(object sender, EventArgs e)
        {
            // !J
        }

        private void btn_write_active_fridge_Click(object sender, EventArgs e)
        {
            // !L
        }

        private void btn_enable_live_monitor_mode_Click(object sender, EventArgs e)
        {
            // !K
        }

        private void btn_dnwld_eeprom_Click(object sender, EventArgs e)
        {

        }
        
    }
}
