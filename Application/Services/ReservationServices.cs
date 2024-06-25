
using Application.Models;
using Domain.Entities;
using Domain.Interface;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ReservationServices : IReservationServices

    {
        private readonly IRepositoryUser _repositoryUser;
        private readonly IRepositoryReservation _repositoryReservation;
        private readonly IRepositorySneaker _repositorySneaker;
        public ReservationServices(IRepositoryReservation repositoryReservation, IRepositorySneaker repositorySneaker, IRepositoryUser repositoryUser)
        {
            _repositoryReservation = repositoryReservation;
            _repositorySneaker = repositorySneaker;
            _repositoryUser = repositoryUser;
        }

        //Crud reservation
        public void Create(int idUser)
        {
            var user = _repositoryUser.GetById(idUser)
                ?? throw new Exception("Usuario no encontrado");
            var newReservation = new Reservation()
            {
                IdUser = idUser,
                User = user,
                State = Reservation.ReservationState.Active,
            };
            _repositoryReservation.AddReservation(newReservation);
        }

        public void Delete(int id)
        {
            var obj = _repositoryReservation.GetById(id);

            if (obj == null)
            {
                throw new Exception("no encontrado");
            }
            _repositoryReservation.Delete(obj);
        }

        public List<ReservationDto> GetAll()
        {
            var list = _repositoryReservation.GetAllReservation()
            ?? throw new Exception("No encontrado");

            return ReservationDto.CreateList(list);
        }

        public ReservationDto GetById(int id)
        {
            var obj = _repositoryReservation.GetReservationById(id)
                ?? throw new Exception("No encontrado");

            return ReservationDto.Create(obj);
        }

        //----------------


        public void FinalizedReservation(int id)
        {
            var obj = _repositoryReservation.GetById(id)
              ?? throw new Exception("");

            _repositoryReservation.FinalizedReservation(obj);
        }



        public List<SneakerDto>? AddToReservation(int idSneaker, int idReservation)
        {
            var obj = _repositorySneaker.GetById(idSneaker)
                ?? throw new Exception("Sneaker no encontrada");

            if (_repositorySneaker.CheckAvailableProduct(obj))
            {
                return SneakerDto.CreateList(_repositoryReservation.AddToReservation(obj, idReservation));
            }
            throw new Exception("No hay Stock");
        }


    }
}