using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    public class Savings : Account  //is treated like an Account since Savings is inherited from Account
    {
        //Property
        public double IntRate { get; set; }

        //Method
        public void CalcAndDepositInterest(int months)  //months calculated interest
        {
            //calculate interest
            double interest = Balance * (IntRate / 12) * months;

            //deposit interest
            Deposit(interest);  //Account already has a Deposit Method, so that is why it was used here.  
        }

        public override string ToPrint()  //this will be the Method used when the status of the account needs to appear; override is used because we need to override the default behavior on this ToPrint when it runs @ run time in the Program
        {
            string message = base.ToPrint();  //base means Account Class; base.ToPrint() means that it will execute the ToPrint from the Account Class to Savings.
            return message + ", IntRate=" + IntRate.ToString();
        }
        
    }
}
