using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSounds
{
    public class Sheep : IAnimalSounds
    {
        public string GetAnimalName()
        {
            return "Sheep";
        }

        public string GetAnimalSound()
        {
            return "Baaaaaa";
        }

        public string ToPrint()
        {
            throw new NotImplementedException();
        }    
    }
}
