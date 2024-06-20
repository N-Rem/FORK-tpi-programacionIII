using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AdminServices: IAdminService
    {
        private readonly IRepositoryUser _repositoryUser;
        private readonly IRepositorySneaker _repositorySneaker;
        private readonly IRepositoryReservation _repositoryReservation;
        public AdminServices( IRepositoryUser repositoryUser, IRepositorySneaker repositorySneaker, IRepositoryReservation repositoryReservation)
        {
            _repositoryUser = repositoryUser;
            _repositorySneaker = repositorySneaker;
            _repositoryReservation = repositoryReservation;
        }
        //CRUD ---- ADMIN
        public List<User> GetAdmins()
        {
            return _repositoryUser.GetAll().Where(user=>!user.IsClient).ToList();
        }

        public AdminDto GetById(int id)
        {
            var obj = _repositoryUser.GetById(id)
                 ?? throw new Exception("No encontrado");

            var objDto = new AdminDto()
            {
                Id = obj.Id,
                Name = obj.Name,
                Email= obj.EmailAddress,
                IsClient = obj.IsClient,
            };

            return objDto;
        }


        public AdminDto CreateAdmin (AdminDto adminDto)
        {
            var Admin = new User()
            {
                Name = adminDto.Name,
                Password = adminDto.Password,
                EmailAddress = adminDto.Email,
                IsClient = false
            };

            _repositoryUser.Add(Admin);
           return adminDto;
        }

        public void Update (AdminDto adminDto)
        {
            var admin = new User()
            {
                Id= adminDto.Id,
                Name = adminDto.Name,
                Password = adminDto.Password,
                EmailAddress = adminDto.Email,
            };
            _repositoryUser.Update(admin);
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