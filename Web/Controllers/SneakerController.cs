using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SneakerController : ControllerBase
    {
        private readonly ISneakerServices _senakerServices;
        public SneakerController(ISneakerServices senakerServices)
        {
            _senakerServices = senakerServices;
        }

        [HttpGet("sneaker")]
        public IActionResult GetAll()
        {
            return Ok(_senakerServices.GetSneaker());
        }

        [HttpGet("sneakerById{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_senakerServices.GetById(id));
        }

        [HttpGet("GetByBrand{brand}")]
        public IActionResult GetByBrand([FromRoute] string brand)
        {
            return Ok(_senakerServices.GetByBrand(brand));
        }

        [HttpGet("GetByCategory{category}")]
        public IActionResult GetByCategor([FromRoute] string category)
        {
            return Ok(_senakerServices.GetByCategory(category));
        }
        [HttpPost]
        public IActionResult Cretate(SneakerDto sneakerDto)
        {
            return Ok(_senakerServices.Create(sneakerDto));
        }

        [HttpPut]
        public IActionResult Update([FromBody] SneakerDto sneakerDto, [FromQuery] int idSneaker)
        {
            _senakerServices.Update(sneakerDto, idSneaker);
            return Ok();
        }

        [HttpPut("buySneakers {idReservation}")]
        public IActionResult BuySneakers([FromRoute] int idReservation)
        {
            _senakerServices.BuySneakers(idReservation);
            return Ok();
        }

        [HttpDelete("delete{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _senakerServices.DeleteById(id);
            return Ok();
        }




    }
}