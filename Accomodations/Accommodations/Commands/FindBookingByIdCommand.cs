using Accommodations.Models;

namespace Accommodations.Commands;

public class FindBookingByIdCommand( IBookingService bookingService, Guid bookingId ) : ICommand
{
    public void Execute()
    {
        Booking? booking = bookingService.FindBookingById( bookingId );
        //Вместо записи в консоль сделала выброс исключения
        if ( booking != null )
            // Исправила вывод категории
            Console.WriteLine( $"Booking found: {booking.RoomCategory.Name} for User {booking.UserId}" );
        else
            throw new ArgumentException( "Booking not found." );
    }

    public void Undo()
    {
        Console.WriteLine( $"Undo operation is not supported for {nameof( GetType )}." );
    }
}
