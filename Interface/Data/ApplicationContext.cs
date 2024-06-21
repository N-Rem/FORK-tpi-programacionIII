using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Son las instrucciones de mapeo del ORM
namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        //dbset recive una entidad y permite traducirlo a una tabla y la tabla con ese nombre se traduce a entidad
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Sneaker> sneakers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fuent API
            //Cardinalidad, muchas zapatillas y muchas reservaciones, 1..n 
            modelBuilder.Entity<Reservation>()
                //de muchos a muchos
                .HasMany(x => x.Sneakers)
                .WithMany();


            //relacion entre reservation y user
            modelBuilder.Entity<Reservation>()
                //de uno a muchos, user puede tener muchas reservaciones
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.IdUser);

            //Crea primeos datos en la base de datos.
            modelBuilder.Entity<User>().HasData(CreateUserSeedData());
            modelBuilder.Entity<Sneaker>().HasData(CreateSneakerSeedData());
            modelBuilder.Entity<Reservation>().HasData(CreateReservationSeedData());

        }

        private User[] CreateUserSeedData()
        {
            return new User[]
            {
            new User { Id = 1, Name = "Ana", Password = "Pass1", EmailAddress = "Ana@example.com", IsClient = false },
            new User { Id = 2, Name = "Delfina", Password = "Pass2", EmailAddress = "delfina@example.com", IsClient = false },
            new User { Id = 3, Name = "Juan", Password = "Pass3", EmailAddress = "juan.doe@example.com", IsClient = true },
            new User { Id = 4, Name = "Victoria", Password = "Pass4", EmailAddress = "vicky.sosa@example.com", IsClient = true },
            new User { Id = 5, Name = "Lautaro", Password = "Pass5", EmailAddress = "lautaro.rb@example.com", IsClient = true },
            };
        }

        private Sneaker[] CreateSneakerSeedData()
        {
            return new Sneaker[]
            {
            new Sneaker { Id = 1, Name = "Air Max", Brand = "Nike", Price = 120, Category = "Sports", Stock = 50 },
            new Sneaker { Id = 2, Name = "Classic", Brand = "Adidas", Price = 100, Category = "Casual", Stock = 30 },
            new Sneaker { Id = 3, Name = "ZoomX", Brand = "Nike", Price = 150, Category = "Running", Stock = 20 },
            new Sneaker { Id = 4, Name = "Superstar", Brand = "Adidas", Price = 80, Category = "Casual", Stock = 40 },
            new Sneaker { Id = 5, Name = "Gel-Kayano", Brand = "Adidas", Price = 140, Category = "Running", Stock = 25 },
            new Sneaker { Id = 6, Name = "Chuck Taylor", Brand = "Converse", Price = 60, Category = "Casual", Stock = 35 },
            new Sneaker { Id = 7, Name = "Ultraboost", Brand = "Adidas", Price = 180, Category = "Running", Stock = 15 },
            new Sneaker { Id = 8, Name = "Pegasus", Brand = "Nike", Price = 110, Category = "Sports", Stock = 45 },
            };
        }

        private Reservation[] CreateReservationSeedData()
        {
            //Crea reservaciones sin su lista de Sneaker
            return new Reservation[]
            {
                new Reservation { Id = 1, IdUser = 3, IsFinalized = false },
                new Reservation { Id = 2, IdUser = 4, IsFinalized = false },
                new Reservation { Id = 3, IdUser = 5, IsFinalized = false },
            };            
        }
    }
}