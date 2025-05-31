namespace AnimalSounds
{
    public class Dog : IAnimal
    {
        public string Name => "Dog";
        public string MakeSound()
        {
            return "Ham";
        }
    }
}
