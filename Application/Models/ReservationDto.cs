
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.Reservation;

namespace Application.Models
{
    public class ReservationDto
    {
        public int Id { get; set; }


        public ReservationState State { get; set; }

        public ICollection<Sneaker> Sneakers { get; set; }

        public int IdUser { get; set; }
    }
}
