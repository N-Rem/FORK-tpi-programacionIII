using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client : User
    {
        public Client(int Id, string Name,string Password) 
        {
            this.Id = Id;
            this.Name = Name;
            this.Password = Password;
            this.IsClient = true;
        }
    }
}
