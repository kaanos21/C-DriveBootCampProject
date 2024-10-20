using C_DriveBootCampProject.Entities;
using FluentValidation;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace C_DriveBootCampProject.FluentValidation.CarValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(carbrand=>carbrand.Brand).NotEmpty().WithMessage("Araba Markası Boş Geçilemez").Length(2, 50).WithMessage("Marka 2 ile 50 karakter arasında olmalıdır.");

            RuleFor(carmodel => carmodel.ModelName).NotEmpty().WithMessage("Araba modeli boş geçilemez");

            RuleFor(caryear => caryear.Year).GreaterThan(1850).WithMessage("Araba 1850 den daha eski olamaz");

            RuleFor(carcolor => carcolor.Color).NotEmpty().WithMessage("Araba Rengi boş olamaz.");

            RuleFor(carprice => carprice.Price).GreaterThan(0).WithMessage("Arabanın değeri 0 veya sıfırdan düşük olamaz");
        }
    }
}
