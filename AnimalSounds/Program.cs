using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace AnimalSounds
{
    internal class Program
    {
        static void Main(string[] args)
        {       
            List<Animal> animals = new List<Animal>();

            animals.Add(new Animal("Cat", "Meow"));
            animals.Add(new Animal("Dog", "Ham"));
            animals.Add(new Animal("Cow", "Muu"));
            animals.Add(new Animal("Bird", "CipCirip"));

            foreach (Animal animal in animals)
            {
                Console.WriteLine($"{animal.Type} makes sound: {animal.Sound}");
            }

            Console.ReadLine(); 
        }
    }
    internal class Animal
    {
        public string Type { get; }
        public string Sound { get; }

        public Animal(string type, string sound)
        {
            Type = type;
            Sound = sound;
        }
    }
}
