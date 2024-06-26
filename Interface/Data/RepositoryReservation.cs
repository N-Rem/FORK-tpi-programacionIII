using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class RepositoryReservation : RepositoryBase<Reservation>, IRepositoryReservation
    {
        private readonly ApplicationContext _context;
        public RepositoryReservation(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public Reservation AddReservation(Reservation reservation)
        {
            var user = _context.users.FirstOrDefault(r => r.Id == reservation.IdUser);
            reservation.User = user;
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return reservation;
        }
        
        public ICollection<Reservation>? GetAllReservation()
        {
            var listReservation = _context.Reservations.Include(r => r.Sneakers).ToList()
            ?? throw new Exception("no se econtraron Reservasiones");

            return listReservation;
        }

        public Reservation? GetReservationById(int id)
        {
            return _context.Reservations.Include(r=>r.Sneakers).FirstOrDefault(r => r.Id == id);
        }


        public void AddToReservation(Sneaker sneaker, int reservationId)
        {
            
            var reservation = _context.Reservations.FirstOrDefault(r => r.Id == reservationId)           
                ??throw new Exception("no se encontro la Reservation");
           
            if (reservation.State == Reservation.ReservationState.Finalized)
            {
                throw new Exception("La reservacion esta finalizada");
            }
            
            reservation.Sneakers.Add(sneaker);
            _context.SaveChanges();
            

        }

        public void FinalizedReservation(Reservation reservation)
        {
            reservation.State = Reservation.ReservationState.Finalized;
            _context.SaveChanges();
        }
        /*
        public ICollection<Sneaker> GetSneaker

        public ICollection<Subject> GetStudentSubjects(int studentId) =>
        _context.Students.Include(a => a.SubjectsAttended).ThenInclude(m => m.Professors).Where(a => a.Id == studentId)
        .Select(a => a.SubjectsAttended).FirstOrDefault() ?? new List<Subject>();*/
    }
}