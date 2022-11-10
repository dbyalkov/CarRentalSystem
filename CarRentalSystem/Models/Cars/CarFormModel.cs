using System.ComponentModel.DataAnnotations;

using static CarRentalSystem.Data.DataConstants.Car;

namespace CarRentalSystem.Models.Cars
{
    public class CarFormModel
    {
        [Required]
        [MaxLength(MaxCarMakeLength)]
        [MinLength(MinCarMakeLength)]
        public string Make { get; set; } = null!;

        [Required]
        [MaxLength(MaxCarModelLength)]
        [MinLength(MinCarModelLength)]
        public string Model { get; set; } = null!;

        [Required]
        [MaxLength(MaxCarColorLength)]
        [MinLength(MinCarColorLength)]
        public string Color { get; set; } = null!;

        [Required]
        [MaxLength(MaxCarIsAvailableLength)]
        [MinLength(MinCarIsAvailableLength)]
        public string IsAvailable { get; set; } = null!;
    }
}