using C_DriveBootCampProject.Context;
using C_DriveBootCampProject.FluentValidation.CarValidation;
using C_DriveBootCampProject.Services.CarService;
using FluentValidation;
using FluentValidation.AspNetCore; // FluentValidation k�t�phanesini ekleyin
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Veritaban� ba�lam� i�in SQLite yap�land�rmas�
builder.Services.AddDbContext<DriveBootCampContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:Sql_connection"]);
});

// Araba servisi i�in ba��ml�l�k ekleme
builder.Services.AddScoped<ICarService, CarService>();

// Fluent Validation'� ekleme
builder.Services.AddControllersWithViews()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CarValidator>());

// Uygulama olu�turma
var app = builder.Build();

// HTTP istek boru hatt�n� yap�land�rma
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
