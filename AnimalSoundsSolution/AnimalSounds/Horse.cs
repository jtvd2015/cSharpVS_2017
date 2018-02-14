using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSounds
{
    public class Horse : IAnimalSounds
    {
        public string GetAnimalName()
        {
            return "Horse";
        }

        public string GetAnimalSound()
        {
            return "Neigh, Neigh";
        }

        public string ToPrint()
        {
            throw new NotImplementedException();
        }
    }
}
