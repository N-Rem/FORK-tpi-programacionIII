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
        public ICollection<User> GetAllUser()
        {
            return _context.users.Include(u=>u.Reservations).ToList();
        }
        public User? GetUserById(int id)
        {
            return _context.users.Include(u => u.Reservations).FirstOrDefault(r => r.Id == id);
        }

    }
}
