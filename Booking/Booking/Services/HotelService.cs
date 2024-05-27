using AutoMapper;
using Booking.Models;
using Booking.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Booking.Services
{
    public class HotelService
    {
        private readonly BookingContext bookingContext;
        private readonly IMapper mapper;
        public HotelService(BookingContext bookingContext, IMapper mapper)
        {
            this.bookingContext = bookingContext;
            this.mapper = mapper;
        }

        public HotelDto CreateHotel(HotelDto hotelDto)
        {
            bookingContext.Hotels.Add(mapper.Map<Hotel>(hotelDto));
            bookingContext.SaveChanges();
            return hotelDto;
        }

        public List<HotelDto> GetAllHotels()
        {
            return mapper.Map<List<HotelDto>>(bookingContext.Hotels.Include(x => x.Rooms).ToList());
        }

        public HotelDto GetHotelById(int id)
        {
            Hotel? hotel = bookingContext.Hotels.Include(x => x.Rooms).FirstOrDefault(hotel => hotel.Id == id);
            if (hotel == null)
            {
                throw new NullReferenceException("Hotel not found");
            }
            return mapper.Map<HotelDto>(hotel);
        }

        public HotelDto UpdateHotel(int id, HotelDto updatedHotelDto)
        {
            Hotel? hotel = bookingContext.Hotels.Include(x => x.Rooms).FirstOrDefault(hotel => hotel.Id == id);
            if (hotel == null)
            {
                throw new NullReferenceException("Hotel not found");
            }
            hotel.Name = updatedHotelDto.Name;
            hotel.Latitude = updatedHotelDto.Latitude;
            hotel.Longitude = updatedHotelDto.Longitude;
            bookingContext.SaveChanges();
            return mapper.Map<HotelDto>(hotel);
        }

        public HotelDto DeleteHotel(int id)
        {
            Hotel? hotel = bookingContext.Hotels.Include(x => x.Rooms).FirstOrDefault(hotel => hotel.Id == id);
            if(hotel == null)
            {
                throw new NullReferenceException("Hotel not found");
            }
            bookingContext.Hotels.Remove(hotel);
            bookingContext.SaveChanges();
            return mapper.Map<HotelDto>(hotel);
        }
    }
}
