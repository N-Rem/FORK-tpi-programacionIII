using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        private readonly ApplicationContext _context;
        public RepositoryUser(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        
        public ICollection<Reservation>? GetAllReservationUser(int idUser)
        {
            //se cambia la manerea de traer la lista de todas las reservaciones del usuario. 
            var reservations = _context.Reservations.Where(r => r.IdUser == idUser).ToList()
                 ?? throw new Exception("No se encontro reservas del usuario");
            return reservations;
        }

    }
}
