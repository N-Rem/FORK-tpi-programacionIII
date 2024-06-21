using Domain.Entities;
using Domain.Interface;
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


        public ICollection<Sneaker> AddToReservation(Sneaker sneaker, int reservationId)
        {
            var Reservation = _context.Reservations.FirstOrDefault(r => r.Id == reservationId);
            if (Reservation == null)
            {
                throw new Exception("not found Reservation");
            }

            Reservation.Sneakers.Add(sneaker);
            _context.SaveChanges();

            return Reservation.Sneakers;

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