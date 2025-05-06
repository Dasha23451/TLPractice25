using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;
public class ReservationRepository : IReservationRepository
{
    private readonly List<Reservation> _reservations = new();

    public Reservation? GetById( Guid id )
    {
        return _reservations.FirstOrDefault( p => p.Id == id );
    }

    public List<Reservation> GetAll()
    {
        return _reservations.ToList();
    }

    public List<Reservation> GetByProperty( Guid propertyId )
    {
        return _reservations.Where( r => r.PropertyId == propertyId ).ToList();
    }

    public List<Reservation> GetByDateRange( DateTime? startDate, DateTime? endDate )
    {
        return _reservations.Where( r =>
            ( r.ArrivalDate >= startDate && r.ArrivalDate <= endDate ) ||
            ( r.DepartureDate >= startDate && r.DepartureDate <= endDate ) ||
            ( r.ArrivalDate <= startDate && r.DepartureDate >= endDate ) )
            .ToList();
    }

    public void Create( Reservation reservation )
    {
        _reservations.Add( reservation );
    }

    public void Update( Reservation reservation )
    {
        Reservation? exitingReservation = GetById( reservation.Id );
        if ( exitingReservation is null )
        {
            throw new InvalidOperationException( $"Property with id {reservation.Id} does not exit." );
        }
        exitingReservation = reservation;
    }

    public void Delete( Guid id )
    {
        Reservation? exitingReservation = GetById( id );
        if ( exitingReservation is null )
        {
            throw new InvalidOperationException( $"Property with id {id} does not exit." );
        }
        _reservations?.Remove( exitingReservation );
    }
}
