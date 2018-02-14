using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSounds
{
    public class Rooster : IAnimalSounds
    {
        public string GetAnimalName()
        {
            return "Rooster";
        }

        public string GetAnimalSound()
        {
            return "Cock-a-doodle-doo";
        }

        public string ToPrint()
        {
            throw new NotImplementedException();
        }
    }
}
