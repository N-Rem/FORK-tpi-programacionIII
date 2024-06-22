using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISneakerServices
    {
        List<Sneaker> GetSneaker();
        SneakerDto GetById(int id);
        SneakerDto Create(SneakerDto sneakerDto);
        void Update(SneakerDto sneakerDto);
        void DeleteById(int id);


        List<Sneaker> GetByBrand(string brand);
        List<Sneaker> GetByCategory(string category);
        void Buy(int id);
        bool CheckAvailableProduct(int id);

    }
}
