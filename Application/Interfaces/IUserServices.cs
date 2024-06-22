using Application.Models;
using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserServices
    {
        List<User> GetAdmins();
        AdminDto GetById(int id);
        AdminDto CreateAdmin(AdminDto adminDto);

        void Update(AdminDto adminDto);

        void DeleteById(int id);



    }
}
