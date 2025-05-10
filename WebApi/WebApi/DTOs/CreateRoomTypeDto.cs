namespace WebApi.DTOs;
public class CreateRoomTypeDto
{
    public string Name { get; set; } = string.Empty;
    public decimal DailyPrice { get; set; }
    public string Currency { get; set; } = "RUB";
    public int MinPersonCount { get; set; } = 1;
    public int MaxPersonCount { get; set; } = 2;
    public string Services { get; set; } = string.Empty;
    public string Amenities { get; set; } = string.Empty;
}