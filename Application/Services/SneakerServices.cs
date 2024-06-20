using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SneakerServices: ISneakerService
    {
        private IRepositorySneaker _repositorySneaker;

        public SneakerServices(IRepositorySneaker repositorySneaker)
        {
            _repositorySneaker = repositorySneaker;
        }

        //CRUD ----- Sneaker
        public List<Sneaker> GetSneaker()
        {
            return _repositorySneaker.GetAll();
        }

        public SneakerDto GetById(int id)
        {
            var obj = _repositorySneaker.GetById(id)
                 ?? throw new Exception("No encontrado");

            var objDto = new SneakerDto()
            {
                Id = obj.Id,
                Name = obj.Name,
                Brand = obj.Brand,
                Category = obj.Category,
                Price = obj.Price,
                Stock = obj.Stock
            };

            return objDto;
        }


        public SneakerDto Create(SneakerDto sneakerDto)
        {
            var sneaker = new Sneaker()
            {
                Id= sneakerDto.Id,
                Name = sneakerDto.Name,
                Brand = sneakerDto.Brand,
                Category = sneakerDto.Category,
                Price = sneakerDto.Price,
                Stock= sneakerDto.Stock,
            };

            _repositorySneaker.Add(sneaker);
            return sneakerDto;
        }

        public void Update(SneakerDto sneakerDto)
        {
            var sneaker = new Sneaker()
            {
                Id = sneakerDto.Id,
               Name = sneakerDto.Name,
               Brand = sneakerDto.Brand,
               Category = sneakerDto.Category,
               Price = sneakerDto.Price,
               Stock = sneakerDto.Stock,
            };
            _repositorySneaker.Update(sneaker);
        }

        public void DeleteById(int id)
        {
            var obj = _repositorySneaker.GetById(id);
            if (obj == null)
            {
                throw new Exception("no encontrado");
            }
            _repositorySneaker.Delete(obj);
        }

        //-------------

        public List<Sneaker> GetByBrand(string brand)
        {
            var listObj =  _repositorySneaker.GetByBrand(brand)
                ?? throw new Exception("Marca no encontrada");
            return (List<Sneaker>)listObj;
        }

        public List<Sneaker> GetByCategory(string category)
        {
            var listObj = _repositorySneaker.GetByCategory(category)
                ?? throw new Exception("Categoria no encontrada");
            return (List<Sneaker>)listObj;
        }

        public void Buy(int id)
        {
            var obj = _repositorySneaker.GetById(id) 
                ?? throw new Exception("No se encontro el producto");
            _repositorySneaker.Buy(obj);
        }

        public bool CheckAvailableProduct(int id)
        {
            var obj = _repositorySneaker.GetById(id)
                ?? throw new Exception("No se encontro el producto");
            return _repositorySneaker.CheckAvailableProduct(obj);
        }

    }
}
