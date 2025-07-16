using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Reservation
{
    public Guid Id { get; set; }
    public Guid PropertyId { get; set; }
    public Guid RoomTypeId { get; set; }
    public Property Property { get; set; }
    [DataType( DataType.Date )]
    public DateTime ArrivalDate { get; set; }

    [DataType( DataType.Date )]
    public DateTime DepartureDate { get; set; }
    public string ArrivalTime { get; set; }
    public string DepartureTime { get; set; }
    public string GuestName { get; set; }
    public string GuestPhoneNumber { get; set; }
    public decimal Total { get; set; }
    public string Currency { get; set; }
    public bool IsCancelled { get; set; } = false;

    public Reservation()
    {
        Id = Guid.NewGuid();
    }
}