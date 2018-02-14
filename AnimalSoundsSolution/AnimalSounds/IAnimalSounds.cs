using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSounds
{
    public interface IAnimalSounds //To rename the Interface so it changes across all files that use it, right click on IAnimalSounds, select Rename... Rename it and then Apply button
    {
        string GetAnimalName();  //To rename the GetAnimalName so it changes across all files that use it, right click on GetAnimalName, select Rename... Rename it and then Apply button
        string GetAnimalSound();  ////To rename the GetAnimalSound so it changes across all files that use it, right click on GetAnimalSound, select Rename... Rename it and then Apply button
        string ToPrint();
    }
}
