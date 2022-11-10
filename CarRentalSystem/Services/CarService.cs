using CarRentalSystem.Data;
using CarRentalSystem.Data.Entities;
using CarRentalSystem.Models.Cars;

using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services
{
    public class CarService : ICarService
    {
        private readonly CarRentalDbContext data;

        public CarService(CarRentalDbContext _data)
        {
            data = _data;
        }

        public async Task AddCarAsync(CarFormModel model)
        {
            var car = new Car()
            {
                Make = model.Make,
                Model = model.Model,
                Color = model.Color,
                IsAvailable = model.IsAvailable
            };

            await data.Cars.AddAsync(car);
            await data.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = await data.Cars.FindAsync(id);

            if (car == null)
            {
                throw new ArgumentException("Invalid car ID");
            }

            data.Cars.Remove(car);
            await data.SaveChangesAsync();
        }

        public async Task<CarFormModel> EditCarAsync(int id)
        {
            var car = await data.Cars.FindAsync(id);

            if (car == null)
            {
                throw new ArgumentException("Invalid car ID");
            }

            return new CarFormModel()
            {
                Make = car.Make,
                Model = car.Model,
                Color = car.Color,
                IsAvailable = car.IsAvailable
            };
        }

        public async Task EditCarAsync(int id, CarFormModel carModel)
        {
            var car = await data.Cars.FindAsync(id);

            if (car == null)
            {
                throw new ArgumentException("Invalid car ID");
            }

            car.Make = carModel.Make;
            car.Model = carModel.Model;
            car.Color = carModel.Color;
            car.IsAvailable = carModel.IsAvailable;

            await data.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarViewModel>> GetAllCarsAsync()
        {
            return await data
                .Cars
                .Select(c => new CarViewModel()
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    Color = c.Color,
                    IsAvailable = c.IsAvailable
                })
                .ToListAsync();
        }

        public async Task RentCarAsync(int id)
        {
            var car = await data.Cars.FindAsync(id);

            if (car == null)
            {
                throw new ArgumentException("Invalid car ID");
            }

            if (car.IsAvailable == "Available")
            {
                car.IsAvailable = "Not Available";
            }

            await data.SaveChangesAsync();
        }
    }
}