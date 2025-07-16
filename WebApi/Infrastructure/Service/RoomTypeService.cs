using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Service;
public class RoomTypeService : IRoomTypeService
{
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IPropertyRepository _propertyRepository;

    public RoomTypeService( IRoomTypeRepository roomTypeRepository, IPropertyRepository propertyRepository )
    {
        _roomTypeRepository = roomTypeRepository;
        _propertyRepository = propertyRepository;
    }

    public RoomType? GetRoomTypeById( Guid id )
    {
        return _roomTypeRepository.GetById( id );
    }

    public List<RoomType> GetRoomTypesForProperty( Guid propertyId )
    {
        return _roomTypeRepository.GetAllByPropertyId( propertyId );
    }

    public RoomType CreateRoomType( RoomType roomType )
    {
        var property = _propertyRepository.GetById( roomType.PropertyId );
        if ( property == null )
        {
            throw new ArgumentException( "Property not found" );
        }

        _roomTypeRepository.Create( roomType );
        return roomType;
    }

    public void UpdateRoomType( RoomType roomType )
    {
        _roomTypeRepository.Update( roomType );
    }

    public void DeleteRoomType( Guid id )
    {
        _roomTypeRepository.Delete( id );
    }
}
