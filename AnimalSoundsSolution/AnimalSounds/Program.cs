using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSounds
{
    class Program
    {
        static void Main(string[] args)
        {
            //no inheritance needed, but an interface will be needed

            //create classes that represent animals that makes sounds, what is the animal and what sound does it make

            Cat cat = new Cat();
            Dog dog = new Dog();
            Chicken chicken = new Chicken();
            Rooster rooster = new Rooster();
            Horse horse = new Horse();
            Pig pig = new Pig();
            Duck duck = new Duck();
            Cow cow = new Cow();
            Sheep sheep = new Sheep();
            Piano piano = new Piano();
            

            //put all animals in a collection 

            IAnimalSounds[] animals = { cat, dog, chicken, rooster, horse, pig, duck, cow, sheep, piano };

            foreach (IAnimalSounds animal in animals)
            {
                string animalName = animal.GetAnimalName();
                string animalSound = animal.GetAnimalSound();

                //return message: "The animal "" makes the sound """
                string message = $"A {animalName} says {animalSound}.";
                Console.WriteLine(message);
            }

            Console.ReadKey();

            //goal of the program is to output the animals that make sounds

        }
    }
}
