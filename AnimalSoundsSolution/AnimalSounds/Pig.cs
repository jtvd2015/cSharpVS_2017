using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSounds
{
    public class Pig : IAnimalSounds
    {
        public string GetAnimalName()
        {
            return "Pig";
        }

        public string GetAnimalSound()
        {
            return "Oink, Oink";
        }

        public string ToPrint()
        {
            throw new NotImplementedException();
        }
    }
}
