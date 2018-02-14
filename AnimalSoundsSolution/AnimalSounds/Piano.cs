using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSounds  
{
    public class Piano : IAnimalSounds
    {
        public string GetAnimalName()
        {
            return "Piano";
        }

        public string GetAnimalSound()
        {
            return "playing a melody";
        }

        public string ToPrint()
        {
            throw new NotImplementedException();
        }
    }
}
