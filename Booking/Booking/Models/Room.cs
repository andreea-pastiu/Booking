using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public RoomType RoomType { get; set; }
        public double Price { get; set; }
        public Hotel Hotel { get; set; }
        [InverseProperty("Room")]
        public List<Booking> Bookings { get; set; }
    }
}
