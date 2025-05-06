using AutoMapper;
using Domain.Entities;
using WebApi.DTOs;

namespace WebApi.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Property, PropertyDto>();
        CreateMap<CreatePropertyDto, Property>();

        CreateMap<RoomType, RoomTypeDto>();
        CreateMap<CreateRoomTypeDto, RoomType>();

        CreateMap<Reservation, ReservationDto>();
        CreateMap<CreateReservationDto, Reservation>();

        CreateMap<AvailableRoomType, AvailableRoomTypeDto>();
    }
}