using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acct1 = new Account();
            acct1.Id = 1;
            acct1.Description = "Account";
            acct1.Balance = 0.0;
            acct1.Owner = new Customer(100, "Jennifer Wesselman");
            Console.WriteLine(acct1.ToPrint());

            acct1.Deposit(5.00);
            Console.WriteLine(acct1.ToPrint());

            acct1.Deposit(-5.00);
            Console.WriteLine(acct1.ToPrint());

            acct1.Withdraw(5000.00);
            Console.WriteLine(acct1.ToPrint());

            Savings sv2 = new Savings();
            sv2.Id = 2;
            sv2.Description = "Savings Account";
            sv2.Balance = 0.0;
            sv2.Owner = new Customer(101, "Jennifer Wesselman");
            sv2.IntRate = 0.12;

            sv2.Deposit(1000.00);
            Console.WriteLine(sv2.ToPrint());

            Checking ck3 = new Checking();
            ck3.Id = 3;
            ck3.Description = "Checking Account";
            ck3.Balance = 0.0;
            ck3.Owner = new Customer(102, "Jennifer Wesselman");
            
            ck3.Deposit(3000);
            Console.WriteLine(ck3.ToPrint());

            //print out monthly statement(s) with chk1 desc balance and total at the bottom
            Checking cka = new Checking();
            cka.Id = 4;
            cka.Description = "Checking Account";
            cka.Balance = 0.0;
            cka.Owner = new Customer(103, "Jude Wesselman");

            cka.Deposit(3000);
            

            Savings sva = new Savings();
            sva.Id = 6;
            sva.Description = "Savings Account";
            sva.Balance = 0.0;
            sva.Owner = new Customer(105, "Jude Wesselman");
            sva.IntRate = 0.12;

            sva.Deposit(1000.00);
            

            Checking ckb = new Checking();
            ckb.Id = 5;
            ckb.Description = "Checking Account";
            ckb.Balance = 0.0;
            ckb.Owner = new Customer(104, "Carole Wesselman");

            ckb.Deposit(3000);

            Savings svb = new Savings();
            svb.Id = 6;
            svb.Description = "Savings Account";
            svb.Balance = 0.0;
            svb.Owner = new Customer(106, "Carole Wesselman");
            svb.IntRate = 0.12;

            svb.Deposit(1000.00);

            Account[] accounts = { cka, ckb, sva, svb };  //Account type was used because it was the common denominator between Checking and Savings Accounts

            double grandTotal = 0;  
            foreach (Account acct in accounts)  //first Account is a Class type, second acct is a variable, third account is the collection
            {
                double acctBalance = acct.GetBalance();  //acctBalance variable is grabbing the Balance of each account
                grandTotal = grandTotal + acctBalance;  //then the Balance is going to be added and show the grandTotal variable
                Console.WriteLine(acct.ToPrint());
            }
            Console.WriteLine("Grand Total is " + grandTotal.ToString());  //current output shows the Grand Total, but does not show whether they are Checking Accounts or Savings Accounts, but since adding virtual and override to Account, Checking, and Saving Classes, it prints correctly

            Console.ReadKey(); //touch any key and the window will disappear
        }
    }
}
