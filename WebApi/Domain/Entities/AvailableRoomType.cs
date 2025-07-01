namespace Domain.Entities;
public class AvailableRoomType
{
    public RoomType RoomType { get; set; }
    public Property Property { get; set; }
    public decimal TotalPrice { get; set; }
    public AvailableRoomType( RoomType roomType, Property property, decimal totalPrice )
    {
        RoomType = roomType;
        Property = property;
        TotalPrice = totalPrice;
    }
}