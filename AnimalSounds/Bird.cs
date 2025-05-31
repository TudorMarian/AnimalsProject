namespace AnimalSounds
{
    public class Bird : IAnimal
    {
        public string Name => "Bird";
        public string MakeSound()
        {
            return "CipCirip";
        }
    }
}
