using Booking.Models;
using Booking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelService hotelService;
        public HotelController(HotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            return Ok(hotelService.GetAllHotels());
        }

        [HttpGet("/{id}")]
        public IActionResult GetHotelById(int id) 
        {
            try
            {
                return Ok(hotelService.GetHotelById(id));
            }
            catch (NullReferenceException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateHotel(Hotel hotel)
        {
            return Ok(hotelService.CreateHotel(hotel));
        }

        [HttpPut("/{id}")]
        public IActionResult UpdateHotel(int id, Hotel updatedHotel)
        {
            try
            {
                return Ok(hotelService.UpdateHotel(id, updatedHotel));
            }
            catch(NullReferenceException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpDelete("/{id}")]
        public IActionResult DeleteHotel(int id)
        {
            try
            {
                return Ok(hotelService.DeleteHotel(id));
            }
            catch(NullReferenceException exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}
