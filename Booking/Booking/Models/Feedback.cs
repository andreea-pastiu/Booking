namespace Booking.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public int OverallRating { get; set; }
        public int ServiceRating { get; set; }
        public int CleanlinessRating { get; set; }
        public string? Comment { get; set; }
    }
}
