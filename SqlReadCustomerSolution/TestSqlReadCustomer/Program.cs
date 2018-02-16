using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlReadCustomer;  //.exe has a reference to the .dll

namespace TestSqlReadCustomer
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerController cust = new CustomerController();

            Customer c = new Customer();

            c.Id = 9;
            c.Name = "SuperMAX";
            c.City = "Mason";
            c.State = "OH";
            c.IsCorpAcct = true;
            c.CreditLimit = 1000000;
            c.Active = true;

            if(!cust.Delete(c)) {
                Console.WriteLine("Delete failed");
            }
            List<Customer> customers = cust.List();
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{customer.Id} | {customer.Name} | {customer.City} | {customer.State} | {customer.IsCorpAcct} | {customer.CreditLimit} | {customer.Active}");
            }
            Console.ReadKey();

            /*CustomerController cust = new CustomerController();*/  //created a class called SqlCustomer and it has been initialized so it will return a list of customers
            //List<Customer> customers = cust.List();  

            //List<Customer> customers = cust.SearchByName("in");
            //foreach (Customer customer in customers)
            //{
            //    Console.WriteLine($"{customer.Id} | {customer.Name} | {customer.City} | {customer.State} | {customer.IsCorpAcct} | {customer.CreditLimit} | {customer.Active}");
            //}

            //List<Customer> customers = cust.SearchByCreditLimitRange(300000, 1000000);
            //foreach (Customer customer in customers)
            //{
            //    Console.WriteLine($"{customer.Id} | {customer.Name} | {customer.City} | {customer.State} | {customer.IsCorpAcct} | {customer.CreditLimit} | {customer.Active}");
            //}


            //Customer customer = cust.Get(2);
            //Console.WriteLine($"{customer.Id} | {customer.Name} | {customer.City} | {customer.State} | {customer.IsCorpAcct} | {customer.CreditLimit} | {customer.Active}");
        }
    }
}
