using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UserRepository : RepositoryBase<User>
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

       public List<Sneaker> GetByBrand(string brand)
       {
           return (List<Sneaker>)_context.Set<Sneaker>().ToList().Where(sneaker => sneaker.Brand == brand);
       }
    }
}
