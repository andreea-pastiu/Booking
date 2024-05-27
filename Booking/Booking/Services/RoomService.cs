using AutoMapper;
using Booking.Models;
using Booking.Models.Dtos;

namespace Booking.Services
{
    public class RoomService
    {
        private readonly BookingContext bookingContext;
        private readonly IMapper mapper;
        public RoomService(BookingContext bookingContext, IMapper mapper)
        {
            this.bookingContext = bookingContext;
            this.mapper = mapper;
        }

        public RoomDto CreateRoom(RoomDto roomDto)
        {
            Room room = mapper.Map<Room>(roomDto);
            room.Hotel = bookingContext.Hotels.FirstOrDefault(hotel => hotel.Id == roomDto.HotelId);
            if(room.Hotel == null)
            {
                throw new NullReferenceException("Hotel not found");
            }
            bookingContext.Rooms.Add(room);
            bookingContext.SaveChanges();
            return roomDto;
        }

        public List<RoomDto> GetAllRooms()
        {
            return mapper.Map<List<RoomDto>>(bookingContext.Rooms.ToList());
        }

        public RoomDto GetRoomById(int id)
        {
            Room? room = bookingContext.Rooms.FirstOrDefault(room => room.Id == id);
            if (room == null)
            {
                throw new NullReferenceException("Room not found");
            }
            return mapper.Map<RoomDto>(room);
        }

        public RoomDto UpdateRoom(int id, RoomDto updatedRoomDto)
        {
            Room? room = bookingContext.Rooms.FirstOrDefault(room => room.Id == id);
            if (room == null)
            {
                throw new NullReferenceException("Room not found");
            }
            room.RoomNumber = updatedRoomDto.RoomNumber;
            room.RoomType = updatedRoomDto.RoomType;
            room.Price = updatedRoomDto.Price;
            room.Hotel = bookingContext.Hotels.FirstOrDefault(hotel => hotel.Id == updatedRoomDto.HotelId);
            if (room.Hotel == null)
            {
                throw new NullReferenceException("Hotel not found");
            }
            bookingContext.SaveChanges();
            return mapper.Map<RoomDto>(room);
        }

        public RoomDto DeleteRoom(int id)
        {
            Room? room = bookingContext.Rooms.FirstOrDefault(room => room.Id == id);
            if (room == null)
            {
                throw new NullReferenceException("Room not found");
            }
            bookingContext.Rooms.Remove(room);
            bookingContext.SaveChanges();
            return mapper.Map<RoomDto>(room);
        }
    }
}
