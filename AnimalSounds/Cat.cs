namespace AnimalSounds
{
    public class Cat : IAnimal
    {
        public string Name => "Cat";
        public string MakeSound()
        {
            return "Meow";
        }
    }
}
