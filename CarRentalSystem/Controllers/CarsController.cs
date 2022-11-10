using CarRentalSystem.Models.Cars;
using CarRentalSystem.Services;

using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;

        public CarsController(ICarService _carService)
        {
            carService = _carService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return View(await carService.GetAllCarsAsync());
        }

        [HttpGet]
        public IActionResult Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(CarFormModel car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }

            try
            {
                await carService.AddCarAsync(car);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An error occurred!");

                return View(car);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await carService.EditCarAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarFormModel carModel)
        {
            await carService.EditCarAsync(id, carModel);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await carService.DeleteCarAsync(id);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Rent(int id)
        {
            try
            {
                await carService.RentCarAsync(id);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An error occurred!");

                return View(nameof(All));
            }
        }
    }
}