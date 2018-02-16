using DisplaySeason;  //make sure the newly created library is referenced here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplaySeason
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplaySeason.Constants constants = new DisplaySeason.Constants();
            Console.WriteLine(constants.GetSeason);  //ensure that the GetSeasons shows as what the library reference is
            Console.ReadKey();
        }
    }
}
