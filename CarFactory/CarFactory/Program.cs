using CarFactory.Cars;
using CarFactory.EnumClass;

class Program
{
    static void Main( string[] args )
    {
        string colorMessage = "Выберите цвет автомобиля:\n" +
            "1 - Красный\n" +
            "2 - Синий\n" +
            "3 - Зеленый\n" +
            "4 - Черный\n" +
            "5 - Желтый\n" +
            "6 - Белый";

        ColorCar color = ( ColorCar )( GetUserChoice( colorMessage, 6 ) - 1 );

        string bodyMessage = "Выберите тип кузова:\n" +
            "1 - Седан\n" +
            "2 - Внедорожник\n" +
            "3 - Хэтчбек\n" +
            "4 - Купе\n" +
            "5 - Кабриолет\n" +
            "6 - Минивэн";
        BodyType body = ( BodyType )( GetUserChoice( bodyMessage, 6 ) - 1 );

        string engineMessage = "Выберите тип двигателя:\n" +
            "1 - V6\n" +
            "2 - V8\n" +
            "3 - Электрический\n" +
            "4 - Дизельный\n" +
            "5 - Гибридный\n" +
            "6 - Турбированный";

        EngineType engine = ( EngineType )( GetUserChoice( engineMessage, 6 ) - 1 );

        string transmissionMessage = "Выберите тип коробки передач:\n" +
            "1 - Механическая\n" +
            "2 - Автоматическая\n" +
            "3 - Полуавтоматическая\n" +
            "4 - CVT";

        TransmissionType transmission = ( TransmissionType )( GetUserChoice( transmissionMessage, 4 ) - 1 );

        ICar car = CarsFactory.CreateCar( color, body, engine, transmission );
        Console.WriteLine( "Конфигурация вашего автомобиля:" );
        Console.WriteLine( car.GetConfiguration() );
    }
    static int GetUserChoice( string message, int max )
    {
        Console.WriteLine( message );
        int choice;
        while ( !int.TryParse( Console.ReadLine(), out choice ) || choice < 1 || choice > max )
        {
            Console.WriteLine( "Неверный ввод. Пожалуйста, выберите число от 1 до 6." );
        }
        return choice;
    }
}
