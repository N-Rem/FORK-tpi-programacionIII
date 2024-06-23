using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{

    public class UserServices: IUserServices

    {
        private readonly IRepositoryUser _repositoryUser;
        public UserServices( IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }
        //CRUD ---- ADMIN
        public List<UserDto> GetAdmins()
        {

            return UserDto.CreateList(_repositoryUser.GetAll().Where(user => user.Type == User.UserType.admin).ToList());

        }

        public List<UserDto> GetClients()
        {

            return UserDto.CreateList(_repositoryUser.GetAll().Where(user => user.Type == User.UserType.client).ToList());

        }

        public List<UserDto> GetUsers()
        {
            return UserDto.CreateList(_repositoryUser.GetAll());
        }

        public UserDto GetById(int id)
        {
            var obj = _repositoryUser.GetById(id)
                 ?? throw new Exception("No encontrado");

            var objDto = new UserDto()
            {
                Id = obj.Id,
                Name = obj.Name,
                EmailAddress= obj.EmailAddress,
                Type = obj.Type,

            };

            return objDto;
        }


        public User CreateUser (UserCreateRequest userDto)
        {
            var user = new User()
            {
                Name = userDto.Name,
                Password = userDto.Password,
                EmailAddress = userDto.EmailAddress,
                Type = userDto.Type,
            };

            _repositoryUser.Add(user);
           return user;
        }

        public void Update (int id, UserUpdateRequest userDto)
        {
            var user = _repositoryUser.GetById(id);

            user.Name = userDto.Name;
            user.Password = userDto.Password;
            user.EmailAddress = userDto.EmailAddress;
            user.Type = userDto.Type;

            _repositoryUser.Update(user);
        }

        public void DeleteById(int id)
        {
            var obj = _repositoryUser.GetById(id);
            if (obj == null)
            {
                throw new Exception("no encontrado");
            }
            _repositoryUser.Delete(obj);
        }


    }
}