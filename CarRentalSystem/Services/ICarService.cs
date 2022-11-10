using CarRentalSystem.Models.Cars;

namespace CarRentalSystem.Services
{
    public interface ICarService
    {
        public Task<IEnumerable<CarViewModel>> GetAllCarsAsync();

        public Task AddCarAsync(CarFormModel model);

        public Task<CarFormModel> EditCarAsync(int id);

        public Task EditCarAsync(int id, CarFormModel carModel);

        public Task DeleteCarAsync(int id);

        public Task RentCarAsync(int id);
    }
}