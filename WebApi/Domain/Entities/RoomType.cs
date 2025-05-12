namespace Domain.Entities;
public class RoomType
{
    public Guid Id { get; set; }
    public Guid PropertyId { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string Currency { get; set; }
    public int MinPersonCount { get; set; }
    public int MaxPersonCount { get; set; }
    public string Services { get; set; }
    public string Amenities { get; set; }
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public RoomType()
    {
        Id = Guid.NewGuid();
    }
}