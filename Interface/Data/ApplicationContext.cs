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
    }
}