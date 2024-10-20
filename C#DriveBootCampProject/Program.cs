using C_DriveBootCampProject.Context;
using C_DriveBootCampProject.FluentValidation.CarValidation;
using C_DriveBootCampProject.Services.CarService;
using FluentValidation;
using FluentValidation.AspNetCore; // FluentValidation kütüphanesini ekleyin
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Veritabaný baðlamý için SQLite yapýlandýrmasý
builder.Services.AddDbContext<DriveBootCampContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:Sql_connection"]);
});

// Araba servisi için baðýmlýlýk ekleme
builder.Services.AddScoped<ICarService, CarService>();

// Fluent Validation'ý ekleme
builder.Services.AddControllersWithViews()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CarValidator>());

// Uygulama oluþturma
var app = builder.Build();

// HTTP istek boru hattýný yapýlandýrma
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
