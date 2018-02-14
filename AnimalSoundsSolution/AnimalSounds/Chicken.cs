using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSounds
{
    public class Chicken : IAnimalSounds
    {
        public string GetAnimalName()
        {
            return "Chicken";
        }

        public string GetAnimalSound()
        {
            return "Cluck Cluck";
        }

        public string ToPrint()
        {
            throw new NotImplementedException();
        }
    }
}
