
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
    public class ReservationService : IReservationService
    {
        private readonly IRepositoryReservation _repositoryReservation;
        private readonly IRepositorySneaker _repositorySneaker;
        public ReservationService (IRepositoryReservation repositoryReservation, IRepositorySneaker repositorySneaker)
        {
            _repositoryReservation = repositoryReservation;
            _repositorySneaker = repositorySneaker;
        }

        //Crud reservation
        public ReservationDto Create(ReservationDto reservation)
        {
            var newReservation = new Reservation()
            {
                Id = reservation.Id,
                IdUser = reservation.IdUser,
                State = Reservation.ReservationState.Active,
            };
            _repositoryReservation.Add(newReservation);
            return reservation;
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

        public List<Reservation> GetAll()
        {
            var list = _repositoryReservation.GetAll();

            return list;
        }

        public ReservationDto GetById(int id)
        {
            var obj = _repositoryReservation.GetById(id)
                ?? throw new Exception("No encontrado");

            var objDto = new ReservationDto()
            {
                Id = obj.Id,
                State = obj.State,
                Sneakers = obj.Sneakers,
                IdUser = obj.IdUser,
            };

            return objDto;
        }

        //----------------


        public void FinalizedReservation(int id)
        {
            var obj = _repositoryReservation.GetById(id)
              ?? throw new Exception("");

            _repositoryReservation.FinalizedReservation(obj);
        }



        public List<Sneaker> AddToReservation(int idSneaker, int idReservation)
        {
            var obj = _repositorySneaker.GetById(idSneaker)
                ?? throw new Exception("");
           
            return (List<Sneaker>)_repositoryReservation.AddToReservation(obj, idReservation);
           
        }


    }
}
