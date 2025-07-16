using Domain.Entities;

namespace Domain.Interfaces;
public interface IRoomTypeService
{
    public RoomType? GetRoomTypeById( Guid id );
    public List<RoomType> GetRoomTypesForProperty( Guid propertyId );
    public RoomType CreateRoomType( RoomType roomType );
    public void UpdateRoomType( RoomType roomType );
    public void DeleteRoomType( Guid id );
}