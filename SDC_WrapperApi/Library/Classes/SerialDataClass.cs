using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    class EEPROMSerialDataClass
    {
        public List<char[]> BaseMAC; //NEW
        public List<UInt16> TempBatteryVoltage;
        public List<byte[]> TempSensorValue; //NEW
        public List<decimal> TempSensorValueConverted;

        public UInt16 ControllerBatteryVoltage;
        public List<byte> DeviceID;// = new List<byte>();        
        public List<byte> DeviceTemp;// = new List<byte>();        
        public List<string> DeviceDateTime;// = new List<string>();

        public List<decimal> ConvertedTemp;
        public Decimal ConvertedBatteryVoltage;
        public List<DateTime> ConvertedDateTime;
        public List<char[]> yy;
        public List<char[]> MM;
        public List<char[]> dd;
        public List<char[]> HH;
        public List<char[]> mm;

        public EEPROMSerialDataClass()
        {
            BaseMAC = new List<char[]>(); //New
            TempSensorValue = new List<byte[]>(); // New
            TempSensorValueConverted = new List<decimal>(); //NEW
            TempBatteryVoltage = new List<UInt16>();

            DeviceID = new List<byte>();            
            DeviceTemp = new List<byte>();            
            DeviceDateTime = new List<string>();
            ConvertedTemp = new List<decimal>();
            ConvertedDateTime = new List<DateTime>();
            yy = new List<char[]>();
            MM = new List<char[]>();
            dd = new List<char[]>();
            HH = new List<char[]>();
            mm = new List<char[]>();

        }
    }

    /*
    public class EEPROM_DOWNLOAD
    {
        public List<byte> DeviceID = new List<byte>();
        public List<byte> DeviceTemp = new List<byte>();
        public List<string> DeviceDateTime = new List<string>();

    }
     */
}
