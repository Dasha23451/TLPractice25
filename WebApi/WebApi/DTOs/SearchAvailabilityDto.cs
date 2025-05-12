namespace WebApi.DTOs;
public class SearchAvailabilityDto
{
    public string City { get; set; } = string.Empty;
    public DateTime ArrivalDate { get; set; } = DateTime.MinValue;
    public DateTime DepartureDate { get; set; } = DateTime.MaxValue;
    public int Guests { get; set; } = 1;
    public decimal? MaxPrice { get; set; }
}
