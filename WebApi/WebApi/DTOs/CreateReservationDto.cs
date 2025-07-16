using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi.DTOs;
public class CreateReservationDto
{
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
}