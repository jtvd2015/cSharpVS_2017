using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    public class Customer
    {
        public int Id { get; set; }
        public string Fullname { get; set; }

        public Customer(int id, string fullname)  //special Method that only occurs when using 'new'
        {
            Id = id;
            Fullname = fullname;
        }
    }
}
