using Car_rental.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Car_rental.Models.Data


{
    public class CarRentalContext : DbContext
    {
        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Car)
                .WithMany()
                .HasForeignKey(r => r.CarId);

            modelBuilder.Entity<User>().HasData(
                  new User
                  {
                      UserId = 1,
                      FirstName = "John",
                      LastName = "Doe",
                      Email = "john.doe@example.com",
                      Password = "Password123", 
                      PhoneNumber = "1234567890",
                      DateOfBirth = new DateTime(1990, 1, 1),
                      AddressLine1 = "123 Main St",
                      AddressLine2 = null,
                      City = "New York",
                      Country = "USA",
                      DriversLicenseNumber = "D123456789",
                      Role = UserRole.User
                  },
                  new User
                  {
                      UserId = 2,
                      FirstName = "Jane",
                      LastName = "Smith",
                      Email = "jane.smith@example.com",
                      Password = "Password123", 
                      PhoneNumber = "0987654321",
                      DateOfBirth = new DateTime(1985, 5, 15),
                      AddressLine1 = "456 Elm St",
                      AddressLine2 = null,
                      City = "Los Angeles",
                      Country = "USA",
                      DriversLicenseNumber = "D987654321",
                      Role = UserRole.Admin
                  }
              );


            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    CarId = 1,
                    Make = "Toyota",
                    Model = "Camry",
                    Year = 2020,
                    PricePerDay = 50,
                    Location = "New York"
                },
                new Car
                {
                    CarId = 2,
                    Make = "Honda",
                    Model = "Civic",
                    Year = 2021,
                    PricePerDay = 45,
                    Location = "Los Angeles"
                },
                new Car
                {
                    CarId = 3,
                    Make = "Ford",
                    Model = "Mustang",
                    Year = 2019,
                    PricePerDay = 75,
                    Location = "Chicago"
                }
            );
        }
    }
}
