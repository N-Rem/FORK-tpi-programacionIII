using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.Sneaker;

namespace Application.Models
{
    public class SneakerDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public SneakerBrand Brand { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "must be a positive value.")] //solo se puede agregar un numero mayor o igual a 0
        public int Price { get; set; }

        [Required]
        public SneakerCategory Category { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "must be a positive value.")]
        public int Stock { get; set; }


    }
}