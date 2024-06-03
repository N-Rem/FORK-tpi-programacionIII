using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sneaker
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "must be a positive value.")] //solo se puede agregar un numero mayor o igual a 0
        public int Price { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "must be a positive value.")]
        public int Stock { get; set; }

        //de uno a muchos, Pero no estoy seguro si esto esta bien.
        [ForeignKey ("Reservation")]
        public int? ReservationId {  get; set; }

        public Reservation Reservation { get; set; }
    }
}
