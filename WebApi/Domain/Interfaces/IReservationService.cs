using Domain.Entities;

namespace Domain.Interfaces;
public interface IReservationService
{
    public List<Reservation> GetAllReservations();
    public Reservation GetReservationById( Guid id );
    public List<Reservation> SearchReservations( Guid? propertyId, DateTime? fromDate, DateTime? toDate, string? guestName );
    public List<AvailableRoomType> SearchAvailableRoomTypes(
            string? city, DateTime? arrivalDate, DateTime? departureDate, int? guests, decimal? maxPrice );
    public Reservation CreateReservation( Reservation reservation );
    void DeleteReservation( Guid id );
}