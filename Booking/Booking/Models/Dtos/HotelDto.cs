using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models.Dtos
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [InverseProperty("Hotel")]
        public List<RoomDto> Rooms { get; set; }
    }
}
