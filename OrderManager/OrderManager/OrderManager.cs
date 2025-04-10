namespace OrderManager
{
    public class Order
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string UserName { get; set; }
        public string DeliveryAddress { get; set; }

        public Order( string userName, string productName, int count, string address )
        {
            UserName = userName;
            ProductName = productName;
            Quantity = count;
            DeliveryAddress = address;
        }
    }
}
