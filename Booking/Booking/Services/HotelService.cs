using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Services
{
    public class HotelService
    {
        private readonly BookingContext bookingContext;
        public HotelService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public Hotel CreateHotel(Hotel hotel)
        {
            bookingContext.Hotels.Add(hotel);
            bookingContext.SaveChanges();
            return hotel;
        }

        public List<Hotel> GetAllHotels()
        {
            return bookingContext.Hotels.Include(x => x.Rooms).ToList();
        }

        public Hotel GetHotelById(int id)
        {
            Hotel hotel = bookingContext.Hotels.Include(x => x.Rooms).FirstOrDefault(hotel => hotel.Id == id);
            if (hotel == null)
            {
                throw new NullReferenceException("Hotel not found");
            }
            return hotel;
        }

        public Hotel UpdateHotel(int id, Hotel updatedHotel)
        {
            Hotel hotel = bookingContext.Hotels.Include(x => x.Rooms).FirstOrDefault(hotel => hotel.Id == id);
            if (hotel == null)
            {
                throw new NullReferenceException("Hotel not found");
            }
            hotel.Name = updatedHotel.Name;
            hotel.Latitude = updatedHotel.Latitude;
            hotel.Longitude = updatedHotel.Longitude;
            bookingContext.SaveChanges();
            return hotel;
        }

        public Hotel DeleteHotel(int id)
        {
            Hotel hotel = bookingContext.Hotels.Include(x => x.Rooms).FirstOrDefault(hotel => hotel.Id == id);
            if(hotel == null)
            {
                throw new NullReferenceException("Hotel not found");
            }
            bookingContext.Hotels.Remove(hotel);
            bookingContext.SaveChanges();
            return hotel;
        }
    }
}
