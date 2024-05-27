namespace Booking.Models.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public RoomType RoomType { get; set; }
        public double Price { get; set; }
        public int HotelId { get; set; }
    }
}
