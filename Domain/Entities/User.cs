using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//comando Update-Database
// Add_Migration AddXXXXXX
//Add-Migration InitialMigration -Context ApplicationContext(primera migracion, Se crea la Base de datos con el ORM)
namespace Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password should be at least 6 characters.")]
        //^inicia la cadena, ?=.*[A-Za-z] en algun lugar de la cadena exista una mayuscual o minuscula
        //?=.*\d Verifica que al menos haya un digito del 0 al 9
        //[A-Za-z\d]{6,} tiene que tener al menos 4 caracteres, mayuscuals, minusculas y numero.
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{4,}$", ErrorMessage = "Password must contain at least one letter and one number.")]
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        public UserType Type { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        //Borrar la lista de reservaciones y poner una funcion para conseguir esta lista en una request?? 

        public enum UserType
        {
            visitor,
            client,
            admin,
        }
    }
}