using Microsoft.EntityFrameworkCore;

namespace Booking.Models
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options): base(options)
        {
        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<BookedDate> BookedDates { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
