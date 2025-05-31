namespace AnimalSounds
{
    public class Cow : IAnimal
    {
        public string Name => "Cow";
        public string MakeSound()
        {
            return "Muu";
        }
    }
}
