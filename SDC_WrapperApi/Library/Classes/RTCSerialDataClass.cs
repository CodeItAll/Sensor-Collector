using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class RTCSerialDataClass
    {
        //public string yyMMddwwHHmmss;
        public char[] yy;
        public char[] MM;
        public char[] dd;
        public char[] ww;
        public char[] HH;
        public char[] mm;

        public RTCSerialDataClass()
        {
            yy = new char[2];
            MM = new char[2];
            dd = new char[2];
            ww = new char[2];
            HH = new char[2];
            mm = new char[2];
        }
    }
}
