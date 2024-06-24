using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        ICollection<User> GetAllUser();
        User? GetUserById(int id);
    }
}