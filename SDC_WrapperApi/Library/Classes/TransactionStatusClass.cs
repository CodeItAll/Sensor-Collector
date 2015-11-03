using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class TransactionStatusClass
    {
        public enum TransactionValues
        {
            SUCCESS,
            FAILED
        }
        
        public TransactionValues TransactionStatus = new TransactionValues();
    }
}
