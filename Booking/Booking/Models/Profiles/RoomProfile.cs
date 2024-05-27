using AutoMapper;
using Booking.Models.Dtos;

namespace Booking.Models.Profiles
{
    public class RoomProfile: Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDto>();
            CreateMap<RoomDto, Room>();
        }
    }
}
