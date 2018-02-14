using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    public class Account : IAccountStatement  //Account had to Interface with IAccountStatement because Account, Checking, and Savings, had a GetBalance Method and ToPrint Method.  If the IAccountStatement was not added, when we tried to run the program, cka, ckb, sva, svb would error in the output when the program ran because the application was looking for a cast when it was not needed because we were performing an Interface
    {
        //Properties
        public int Id { get; set; }
        public string Description { get; set; }
        public double Balance { get; set; }
        public Customer Owner { get; set; }

        //Methods
        public void Deposit(double amount)
        {
            //if (amount < 0)
            //{
            //    Console.WriteLine("Amount cannot be negative.");
            //    return;
            //}
            if(! IsAmountNegative(amount))  //if(! means if not the amount is negative
            {

                Balance = Balance + amount; //variable balance is being added to the current amount; single = is an assignment
            }            
        }

        public void Withdraw(double amount)
        {
            ////if (amount < 0)
            ////{
            ////    Console.WriteLine("Amount cannot be negative.");
            ////    return;
            ////}
            IsAmountNegative(amount);
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }
            if (!IsAmountNegative(amount))  //if(! means if not the amount is negative
            {

                Balance = Balance + amount; //variable balance is being added to the current amount; single = is an assignment
            }            
        }

        public double GetBalance()
        {
            return Balance;
        }

        private bool IsAmountNegative(double amount)  //manually created Method to replace the duplicate code in Withdraw; private modifier is used to ensure that no other Class can call this method and is not intended for use outside of Class Account
        {
            if(amount < 0)
            {
                Console.WriteLine("Amount cannot be negative.");
                return true;
            }
            return false;
        }
        
        public virtual string ToPrint()  //this will be the Method used when the status of the account needs to appear; virtual means that the ToPrint for Checking data and ToPrint for Saving data will print when called in the Program for the monthly balance.
        {
            return "Acct Name=" +Owner.Fullname + ", Id=" + Id.ToString() + ", Desc=" + Description + ", Bal=" + Balance.ToString();
        }
    }
}
