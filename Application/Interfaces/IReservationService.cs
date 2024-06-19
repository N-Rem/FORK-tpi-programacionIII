using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IReservationService
    {
        ReservationDto Create(ReservationDto reservation);
        void Delete(int id);
        List<Reservation> GetAll();
        ReservationDto GetById(int id);
        void FinalizedReservation(int id);
        List<Sneaker> AddToReservation(int idSneaker, int idReservation);
    }
}
