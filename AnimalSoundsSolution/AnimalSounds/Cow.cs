using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSounds
{
    public class Cow : IAnimalSounds
    {
        public string GetAnimalName()
        {
            return "Cow";
        }

        public string GetAnimalSound()
        {
            return "Mooooooo";
        }

        public string ToPrint()
        {
            throw new NotImplementedException();
        }
    }
}
