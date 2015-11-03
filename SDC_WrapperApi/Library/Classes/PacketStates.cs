using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    public class PacketStates
    {
        public enum StateMachine
        {
            Inactive,
            Active
        }

        public enum PacketState
        {
            CLEAR_EEPROM, //!A
            READ_RTC, //!B
            WRITE_RTC, //!C
            DOWNLOAD_EEPROM, //!D
            INACTIVE
        }
    }
}
