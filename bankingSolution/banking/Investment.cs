using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    public class Investment //does not inherit from Account since it is a new Account Type
    {
        public Account account { get; set; }
        
        public void Deposit (double amount)
        {
            account.Deposit(amount);        
        }

        public void Withdraw (double amount)
        {
            account.Withdraw(amount);
        }

        public double GetBalance()
        {
            return (double) account.GetBalance();
        }

        public Investment()
        {
            account = new Account();
            account.Id = 1000;
            account.Description = "Investment";
            account.Balance = 0.0;
            account.Owner = new Customer(111, "Jody Pherrell");

        }

        public string ToPrint()
        {
            string message = account.ToPrint();
            return message + "Investment Account";
        }
    }
}
