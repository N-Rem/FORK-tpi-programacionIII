using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AdminServices
    {
        /*public AdminDto getById(int id)
        {
            return new AdminDto();
        }*/

        /*public List<AdminDto> getAll()
        {
            return new List<AdminDto>();
        }*/
        public void deleteById(int id)
        {

        }

        public void updateById(int id, AdminDto user)
        {

        }

        public AdminDto create(AdminDto user)
        {
            var user2 = new AdminDto(user.Id, user.Name, user.Password, user.Email);
            return user2;
        }


    }
}