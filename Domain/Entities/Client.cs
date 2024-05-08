using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client : User
    {
        public ICollection<Sneaker> sneakers { get; set; }
        public Client(int Id, string Name,string Password) 
        {
            this.Id = Id;
            this.Name = Name;
            this.Password = Password;
            this.IsClient = true;
        }
        public ICollection<Sneaker> ShowSneaker()
        {
            return sneakers; //MOSTRAR ZAPATILLAS
        }

        public ICollection<Sneaker> FilterSneaker(string brand)
        {
            return sneakers; //FILTRAMOS
        }

        public void AddSneaker(int id)
        {
            
        }

        public void RemoveSneaker(int id) 
        {

        }

        public void BuySneaker() 
        { 

        }
    }
}
