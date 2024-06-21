using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdUser { get; set; }

        public ReservationState State { get; set; }

        //de uno a muchos
        [Required]
        public ICollection<Sneaker> Sneakers { get; set; }

        [Required]
        [ForeignKey(("IdUser"))]
        public User User { get; set; }


        public enum ReservationState
        {
            Active,
            Finalized,
        }

    }
}