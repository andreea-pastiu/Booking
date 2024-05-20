using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [InverseProperty("Hotel")]
        public List<Room> Rooms { get; set; }
    }
}
