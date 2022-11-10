using System.ComponentModel.DataAnnotations;

using static CarRentalSystem.Data.DataConstants.Car;

namespace CarRentalSystem.Data.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxCarMakeLength)]
        public string Make { get; set; } = null!;

        [Required]
        [MaxLength(MaxCarModelLength)]
        public string Model { get; set; } = null!;

        [Required]
        [MaxLength(MaxCarColorLength)]
        public string Color { get; set; } = null!;

        [Required]
        [MaxLength(MaxCarIsAvailableLength)]
        public string IsAvailable { get; set; } = null!;
    }
}