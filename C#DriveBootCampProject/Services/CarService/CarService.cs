using C_DriveBootCampProject.Context;
using C_DriveBootCampProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace C_DriveBootCampProject.Services.CarService
{
    public class CarService : ICarService
    {
        private readonly DriveBootCampContext _context;

        public CarService(DriveBootCampContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> CarListAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task CreateCarAsync(Car carDto)
        {
            _context.Cars.Add(carDto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(int carId)
        {
            var value= _context.Cars.Find(carId);
             _context.Cars.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<Car> GetByIdCarAsync(int carId)
        {
            return await _context.Cars.FirstOrDefaultAsync(x => x.CarId == carId);
        }

        public async Task UpdateCarAsync(Car carDto)
        {
            _context.Cars.Update(carDto); 
            await _context.SaveChangesAsync();
        }
    }
}
