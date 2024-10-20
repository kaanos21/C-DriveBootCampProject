using C_DriveBootCampProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace C_DriveBootCampProject.Context
{
    public class DriveBootCampContext:DbContext
    {
        public DriveBootCampContext(DbContextOptions<DriveBootCampContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }  // Car tablolarını temsil eder

        
    }
}
