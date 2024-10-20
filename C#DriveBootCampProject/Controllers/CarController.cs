using C_DriveBootCampProject.Entities;
using C_DriveBootCampProject.Services.CarService;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace C_DriveBootCampProject.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IValidator<Car> _validator;

        public CarController(ICarService carService, IValidator<Car> validator)
        {
            _carService = carService;
            _validator = validator;
        }
        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var value=await _carService.CarListAsync();
            return View(value);
        }
        [HttpGet]
        public IActionResult CreateCar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(Car carDto)
        {
            var validationResult = await _validator.ValidateAsync(carDto);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(carDto); 
            }
            await _carService.CreateCarAsync(carDto);
            return RedirectToAction("CarList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var value=await _carService.GetByIdCarAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(Car carDto)
        {
            var validationResult = await _validator.ValidateAsync(carDto);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(carDto); // Hatalar varsa formu geri gönder
            }

            await _carService.UpdateCarAsync(carDto);
            return RedirectToAction("CarList");
        }
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carService.DeleteCarAsync(id);
            return RedirectToAction("CarList");
        }
        public async Task<IActionResult> CarDetailById(int id)
        {
            var value = await _carService.GetByIdCarAsync(id);
            return View(value);
        }

    }
}
