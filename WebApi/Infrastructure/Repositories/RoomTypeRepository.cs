using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;
public class RoomTypeRepository : IRoomTypeRepository
{
    private readonly List<RoomType> _roomTypes = new();
    public List<RoomType> GetAllByPropertyId( Guid propertyId )
    {
        return _roomTypes.Where( rt => rt.PropertyId == propertyId ).ToList();
    }

    public RoomType? GetById( Guid id )
    {
        return _roomTypes.FirstOrDefault( rt => rt.Id == id );
    }


    public void Create( RoomType roomType )
    {
        _roomTypes.Add( roomType );
    }

    public void Update( RoomType roomType )
    {
        RoomType? exitingRoomType = GetById( roomType.Id );
        if ( exitingRoomType is null )
        {
            throw new InvalidOperationException( $"Property with id {roomType.Id} does not exit." );
        }
        exitingRoomType = roomType;
    }

    public void Delete( Guid id )
    {
        RoomType? exitingRoomType = GetById( id );
        if ( exitingRoomType is null )
        {
            throw new InvalidOperationException( $"Property with id {id} does not exit." );
        }
        _roomTypes?.Remove( exitingRoomType );
    }
}
