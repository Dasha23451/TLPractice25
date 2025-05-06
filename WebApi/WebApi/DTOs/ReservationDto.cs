using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs;
public class ReservationDto
{
    public Guid Id { get; set; }
    public Guid PropertyId { get; set; }
    public Guid RoomTypeId { get; set; }
    [DataType( DataType.Date )]
    public DateTime ArrivalDate { get; set; }

    [DataType( DataType.Date )]
    public DateTime DepartureDate { get; set; }
    public string ArrivalTime { get; set; }
    public string DepartureTime { get; set; }
    public string GuestName { get; set; } = string.Empty;
    public string GuestPhoneNumber { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public string Currency { get; set; } = "RUB";
    public bool IsCancelled { get; set; } = false;
}