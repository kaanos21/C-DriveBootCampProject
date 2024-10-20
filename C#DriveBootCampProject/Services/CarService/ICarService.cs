using C_DriveBootCampProject.Entities;

namespace C_DriveBootCampProject.Services.CarService
{
    public interface ICarService
    {
        Task<List<Car>> CarListAsync(); 
        Task CreateCarAsync(Car carDto); 
        Task UpdateCarAsync(Car carDto); 
        Task DeleteCarAsync(int carId); 
        Task<Car> GetByIdCarAsync(int carId); 
    }
}
