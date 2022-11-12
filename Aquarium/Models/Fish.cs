namespace Aquarium.Models
{
    public class Fish
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Species { get; set; }
        public int Length { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + " Name: " + Name + " Species: " + Species + " Length: " + Length;
        }
        public void ValidateName()
        {
            if (Name == null) throw new ArgumentNullException(nameof(Name));
            if (Name.Length < 2) throw new ArgumentException("Name should be at least 2 char. long");
        }
        public void ValidateSpecies()
        {
            if (Species == null) throw new ArgumentNullException(nameof(Species));
            if (Species.Length < 2) throw new ArgumentException(nameof(Species));
        }
        public void ValidateLength()
        {
            if(Length<0) throw new ArgumentOutOfRangeException(nameof(Length));
        }
        public void Validate()
        {
            ValidateName();
            ValidateSpecies();
            ValidateLength();
        }
    }
}
