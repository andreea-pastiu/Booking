using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Room Room { get; set; }
        [InverseProperty("Booking")]
        public List<BookedDate> BookedDates { get; set; }
        public Feedback Feedback { get; set; }
    }
}
