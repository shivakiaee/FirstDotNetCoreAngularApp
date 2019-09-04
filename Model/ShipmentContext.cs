using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace Model
{
    public class ShipmentContext:DbContext
    {
        public ShipmentContext(DbContextOptions<ShipmentContext> options):base(options)
        {
       
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>().HasData(
                            new Province() { Id =1,Name="Tehran" });

            modelBuilder.Entity<City>().HasData(
                            new City() { Id = 1, Name = "Tehran" ,ProvinceId=1});

            modelBuilder.Entity<Driver>().HasData(
                            new Driver() { Id = 1,FirstName="Shiva"
                            ,LastName="Iype"
                            ,FatherName="John"
                            ,NationalCode="0063445492"
                            ,PhoneNumber="09123723149"
                            ,CityId=1,
                            PostalCode="1234567890"
                            ,Address="Iran-Tehran",
                            Email="Shiva.kiaee@gmail.com"
                            ,Sheba="120000000000014445250000"
                            });
            modelBuilder.Entity<Driver>()
            .HasMany(c => c.Cars)
            .WithOne(e => e.Driver).IsRequired();
        }
        //public DbSet<User> Users { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
