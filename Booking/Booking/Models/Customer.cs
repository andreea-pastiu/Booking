using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models
{
    public class Customer : User
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [InverseProperty("Customer")]
        public List<Booking> Bookings { get; set; }
    }
}
