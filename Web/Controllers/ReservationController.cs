using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_reservationService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(_reservationService.GetById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _reservationService.Delete(id);

            return Ok(null);

        }

        [HttpPost]
        public IActionResult Create([FromBody] ReservationDto dto)
        {
            return Ok(_reservationService.Create(dto));
        }

        [HttpPut("{id}")]
        public IActionResult FinalizedReservation([FromRoute] int id)
        {
            _reservationService.FinalizedReservation(id);
            return Ok("null");
        }

        [HttpPut("{idSneaker}")]
        public IActionResult AddToReservation([FromRoute] int idSneaker, [FromQuery] int idReservation)
        {
            return Ok(_reservationService.AddToReservation(idSneaker, idReservation));
            
        }
    }
}