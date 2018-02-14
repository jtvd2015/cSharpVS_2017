using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    public interface IAccountStatement
    {
        double GetBalance();
        string ToPrint();
    }
}
