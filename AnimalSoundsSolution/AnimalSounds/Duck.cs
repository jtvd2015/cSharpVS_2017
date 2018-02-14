using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSounds
{
    public class Duck : IAnimalSounds
    {
        public string GetAnimalName()
        {
            return "Duck";
        }

        public string GetAnimalSound()
        {
            return "Aflac";
        }

        public string ToPrint()
        {
            throw new NotImplementedException();
        }
    }
}
