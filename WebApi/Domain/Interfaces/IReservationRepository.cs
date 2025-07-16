using Domain.Entities;

namespace Domain.Interfaces;
public interface IReservationRepository
{
    public List<Reservation> GetAll();
    Reservation? GetById( Guid id );
    List<Reservation> GetByProperty( Guid propertyId );
    List<Reservation> GetByDateRange( DateTime? startDate, DateTime? endDate );
    void Create( Reservation reservation );
    void Update( Reservation reservation );
    void Delete( Guid id );
}