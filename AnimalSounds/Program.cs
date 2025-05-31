using System;
using System.Collections.Generic;

namespace AnimalSounds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>
            {
                new Dog(),
                new Cat(),
                new Cow(),
                new Bird()
            };

            foreach (var animal in animals)
            {
                Console.WriteLine($"{animal.Name} makes sound: {animal.MakeSound()}");
            }

            Console.ReadLine();
        }
    }
}
