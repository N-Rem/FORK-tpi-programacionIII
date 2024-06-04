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
        [Required]
        public int Id { get; set; }

        //de uno a muchos
        [Required]
        public ICollection<Sneaker> Sneakers { get; set; } = new List<Sneaker>();

        //De uno a muchos
        [ForeignKey("Client")]
        public int ClientId {  get; set; }

        [Required]
        public User Client { get; set; }
    }
}
