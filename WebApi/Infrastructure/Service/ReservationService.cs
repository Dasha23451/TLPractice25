using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Service;
public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IPropertyRepository _propertyRepository;

    public ReservationService(
        IReservationRepository reservationRepository,
        IRoomTypeRepository roomTypeRepository,
        IPropertyRepository propertyRepository )
    {
        _reservationRepository = reservationRepository;
        _roomTypeRepository = roomTypeRepository;
        _propertyRepository = propertyRepository;
    }

    public Reservation? GetReservationById( Guid id )
    {
        return _reservationRepository.GetById( id );
    }

    public List<Reservation> GetAllReservations()
    {
        return _reservationRepository.GetAll();
    }

    public List<Reservation> SearchReservations(
        Guid? propertyId, DateTime? fromDate, DateTime? toDate, string? guestName )
    {
        var allReservations = _reservationRepository.GetAll();

        var query = allReservations.AsQueryable();

        if ( propertyId.HasValue )
        {
            query = query.Where( r => r.PropertyId == propertyId.Value );
        }

        if ( fromDate.HasValue )
        {
            query = query.Where( r => r.DepartureDate >= fromDate.Value );
        }

        if ( toDate.HasValue )
        {
            query = query.Where( r => r.ArrivalDate <= toDate.Value );
        }

        if ( !string.IsNullOrEmpty( guestName ) )
        {
            query = query.Where( r => r.GuestName.Contains( guestName, StringComparison.OrdinalIgnoreCase ) );
        }

        return query.ToList();
    }

    public List<AvailableRoomType> SearchAvailableRoomTypes(
        string? city, DateTime? arrivalDate, DateTime? departureDate, int? guests, decimal? maxPrice )
    {
        if ( string.IsNullOrEmpty( city ) && !arrivalDate.HasValue && !departureDate.HasValue && !guests.HasValue && !maxPrice.HasValue )
        {
            throw new ArgumentException( "At least one search parameter must be provided." );
        }

        if ( !arrivalDate.HasValue )
        {
            arrivalDate = DateTime.MinValue;
        }

        if ( !departureDate.HasValue )
        {
            departureDate = DateTime.MaxValue;
        }

        if ( arrivalDate >= departureDate )
        {
            throw new ArgumentException( "Departure date must be after arrival date" );
        }

        var properties = _propertyRepository.GetAll()
            .Where( p => p.City.Equals( city, StringComparison.OrdinalIgnoreCase ) )
            .ToList();

        var roomTypes = new List<RoomType>();
        foreach ( var property in properties )
        {
            var propertyRoomTypes = _roomTypeRepository.GetAllByPropertyId( property.Id );
            roomTypes.AddRange( propertyRoomTypes );
        }

        roomTypes = roomTypes
            .Where( rt => rt.MinPersonCount <= guests && rt.MaxPersonCount >= guests )
            .Where( rt => maxPrice == null || rt.DailyPrice <= maxPrice )
            .ToList();

        var reservations = _reservationRepository.GetByDateRange( arrivalDate, departureDate );

        var availableRoomTypes = new List<AvailableRoomType>();
        foreach ( var roomType in roomTypes )
        {
            var overlappingReservations = reservations
                .Where( r => r.RoomTypeId == roomType.Id && !r.IsCancelled )
                .ToList();

            if ( !overlappingReservations.Any() )
            {
                var property = properties.First( p => p.Id == roomType.PropertyId );
                var nights = departureDate - arrivalDate;
                int days = nights.HasValue ? nights.Value.Days : 0;
                var totalPrice = roomType.DailyPrice * days;

                availableRoomTypes.Add( new AvailableRoomType( roomType, property, totalPrice ) );
            }
        }

        return availableRoomTypes;
    }

    public Reservation CreateReservation( Reservation reservation )
    {
        if ( reservation.ArrivalDate >= reservation.DepartureDate )
        {
            throw new ArgumentException( "Departure date must be after arrival date" );
        }

        var roomType = _roomTypeRepository.GetById( reservation.RoomTypeId );
        if ( roomType == null )
        {
            throw new ArgumentException( "Room type not found" );
        }

        var property = _propertyRepository.GetById( reservation.PropertyId );
        if ( property == null )
        {
            throw new ArgumentException( "Property not found" );
        }

        var reservations = _reservationRepository.GetByDateRange(
            reservation.ArrivalDate, reservation.DepartureDate );

        var overlappingReservations = reservations
            .Where( r => r.RoomTypeId == reservation.RoomTypeId && !r.IsCancelled )
            .ToList();

        if ( overlappingReservations.Any() )
        {
            throw new InvalidOperationException( "Room type is not available for the selected dates" );
        }

        var nights = ( reservation.DepartureDate - reservation.ArrivalDate ).Days;
        reservation.Total = roomType.DailyPrice * nights;
        reservation.Currency = roomType.Currency;

        _reservationRepository.Create( reservation );
        return reservation;
    }

    public void DeleteReservation( Guid id )
    {
        _reservationRepository.Delete( id );
    }
}