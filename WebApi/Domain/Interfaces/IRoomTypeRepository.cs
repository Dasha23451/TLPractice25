using Domain.Entities;

namespace Domain.Interfaces;
public interface IRoomTypeRepository
{
    public List<RoomType> GetAllByPropertyId( Guid propertyId );
    public RoomType GetById( Guid id );
    public void Create( RoomType roomType );
    public void Update( RoomType roomType );
    public void Delete( Guid id );
}