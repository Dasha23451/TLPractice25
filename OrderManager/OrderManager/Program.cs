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

class Program
{
    static void GetOrderDetails()
    {
        Console.Clear();
        var order = CreateOrder();
        ConfirmOrder( order );

        Console.WriteLine( "\nНажмите любую клавишу для возврата в меню..." );
        Console.ReadKey();
    }
    static Order CreateOrder()
    {
        Console.WriteLine( "\nПожалуйста, введите данные для заказа:" );
        string userName = GetInput( "Ваше имя: " );
        string productName = GetInput( "Название товара: " );
        int quantity = GetQuantity();
        string deliveryAddress = GetInput( "Адрес доставки: " );

        return new Order( userName, productName, quantity, deliveryAddress );
    }

    static string GetInput( string prompt )
    {
        string input;
        do
        {
            Console.Write( prompt );
            input = Console.ReadLine()?.Trim();

            if ( string.IsNullOrEmpty( input ) )
            {
                Console.WriteLine( "Поле не может быть пустым. Пожалуйста, введите значение." );
            }
        } while ( string.IsNullOrEmpty( input ) );

        return input;
    }

    static int GetQuantity()
    {
        int quantity;
        while ( true )
        {
            Console.Write( "Количество товара: " );
            if ( int.TryParse( Console.ReadLine(), out quantity ) && quantity > 0 )
            {
                return quantity;
            }
            Console.WriteLine( "Некорректное количество. Пожалуйста, введите положительное целое число." );
        }
    }

    static void ConfirmOrder( Order order )
    {
        Console.WriteLine( "\n--------------------------------------------" );
        Console.WriteLine( $"Здравствуйте, {order.UserName}, вы заказали {order.Quantity} {order.ProductName} " +
                         $"на адрес {order.DeliveryAddress}, все верно?" );
        Console.Write( "Подтвердите заказ (да/нет): " );

        var confirmation = Console.ReadLine()?.Trim().ToLower();

        if ( confirmation == "да" || confirmation == "yes" || confirmation == "y" )
        {
            CompleteOrder( order );
        }
        else
        {
            Console.WriteLine( "Заказ отменен. Вы можете начать оформление заново." );
        }
    }

    static void CompleteOrder( Order order )
    {
        var deliveryDate = DateTime.Now.AddDays( 3 ).ToString( "dd.MM.yyyy" );

        Console.WriteLine( "\n--------------------------------------------" );
        Console.WriteLine( $"{order.UserName}! Ваш заказ {order.ProductName} в количестве {order.Quantity} " +
                        $"оформлен! Ожидайте доставку по адресу {order.DeliveryAddress} к {deliveryDate}" );
    }

    static void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine( "Добро пожаловать в систему оформления заказов!" );
        Console.WriteLine( "--------------------------------------------" );
        Console.WriteLine( "Выберите действие:" );
        Console.WriteLine( "1. Сделать заказ" );
        Console.WriteLine( "2. Выйти из программы" );
        Console.Write( "Ваш выбор: " );
    }

    static void Main( string[] args )
    {
        bool isRunning = true;

        while ( isRunning )
        {
            PrintMenu();
            var choice = Console.ReadLine();

            switch ( choice )
            {
                case "1":
                    GetOrderDetails();
                    break;
                case "2":
                    isRunning = false;
                    Console.WriteLine( "\nСпасибо за использование нашего сервиса! До свидания!" );
                    break;
                default:
                    Console.WriteLine( "\nНекорректный ввод. Пожалуйста, выберите 1 или 2." );
                    Console.WriteLine( "Нажмите любую клавишу для продолжения..." );
                    Console.ReadKey();
                    break;
            }
        }
    }
}