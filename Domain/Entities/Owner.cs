using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Owner : User
    {
        public Owner(int Id, string Name, string Password)
        {
            this.Id = Id;
            this.Name = Name;
            this.Password = Password;
            this.IsClient = false;
        }
    }
}
