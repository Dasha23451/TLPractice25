namespace WebApi.DTOs;
public class AvailableRoomTypeDto
{
    public RoomTypeDto RoomType { get; set; } = null!;
    public PropertyDto Property { get; set; } = null!;
    public decimal TotalPrice { get; set; }
}
