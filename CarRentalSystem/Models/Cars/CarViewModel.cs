namespace CarRentalSystem.Models.Cars
{
    public class CarViewModel
    {
        public int Id { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Color { get; set; } = null!;

        public string IsAvailable { get; set; } = null!;
    }
}