using Booking.Models.Dtos;
using Booking.Services;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly RoomService roomService;
        public RoomController(RoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet]
        public IActionResult GetAllRooms()
        {
            return Ok(roomService.GetAllRooms());
        }

        [HttpGet("{id}")]
        public IActionResult GetRoomById(int id)
        {
            try
            {
                return Ok(roomService.GetRoomById(id));
            }
            catch (NullReferenceException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateRoom(RoomDto roomDto)
        {
            return Ok(roomService.CreateRoom(roomDto));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRoom(int id, RoomDto updatedRoomDto)
        {
            try
            {
                return Ok(roomService.UpdateRoom(id, updatedRoomDto));
            }
            catch (NullReferenceException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            try
            {
                return Ok(roomService.DeleteRoom(id));
            }
            catch (NullReferenceException exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}
