
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ReservationDto
    {
        public int Id { get; set; }


        public bool IsFinalized { get; set; }

        public ICollection<Sneaker> Sneakers { get; set; }

        public int IdUser { get; set; }
    }
}
