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
            var user = _context.users.FirstOrDefault(u => u.Id == idUser)
                 ?? throw new Exception("Usuario no encontrado");
            return user.Reservations;
        }

    }
}
