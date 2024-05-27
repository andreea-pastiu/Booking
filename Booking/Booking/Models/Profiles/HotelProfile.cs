using AutoMapper;
using Booking.Models.Dtos;

namespace Booking.Models.Profiles
{
    public class HotelProfile: Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, HotelDto>();
            CreateMap<HotelDto, Hotel>();
        }
    }
}
