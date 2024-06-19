using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class RepositoryUser : RepositoryBase<User>
    {
        private readonly ApplicationContext _context;
        public RepositoryUser(ApplicationContext context) : base(context)
        {
            _context = context;
        }

       public List<Sneaker> GetByBrand(string brand)
       {
           return (List<Sneaker>)_context.Set<Sneaker>().ToList().Where(sneaker => sneaker.Brand == brand);
       }
    }
}
