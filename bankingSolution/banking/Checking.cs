using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    public class Checking : Account  //is treated like an Account since Checking is inherited from Account
    {
        public int LastCheckNumber { get; set; }

        public override string ToPrint()  //override is used because we need to override the default behavior on this ToPrint when it runs @ run time in the Program
        {
            string message = base.ToPrint();  //base means Account Class; base.ToPrint() means that it will execute the ToPrint from the Account Class to Checking.
            return message + ", LastCheck=" + LastCheckNumber.ToString();
        }
    }
}
