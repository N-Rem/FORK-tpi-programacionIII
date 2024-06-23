using Application.Models;
using Application.Models.Requests;
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
        List<UserDto> GetAdmins();
        List<UserDto> GetClients();
        List<UserDto> GetUsers();
        UserDto GetById(int id);
        User CreateUser(UserCreateRequest userDto);
        void Update(int id, UserUpdateRequest userDto);
        void DeleteById(int id);



    }
}
