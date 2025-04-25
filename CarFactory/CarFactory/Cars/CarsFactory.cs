using CarFactory.Cars;
using CarFactory.Color;
using CarFactory.BodyType;
using CarFactory.EngineType;
using CarFactory.TransmissionType;

namespace CarFactory;
public class CarsFactory
{
    public ICar Generate()
    {
        IColor color = GetColorFromUser();
        IBodyType body = GetBodyTypeFromUser();
        IEngineType engine = GetEngineTypeFromUser();
        ITransmissionType transmission = GetTransmissionTypeFromUser();

        return new Car( color, body, engine, transmission );
    }
    public string GetCarConfiguration( ICar car )
    {
        return $"Конфигурация автомобиля:\n" +
               $"Цвет: {car.Color.Name}\n" +
               $"Кузов: {car.Body.Name}\n" +
               $"Двигатель: {car.Engine.Name}\n" +
               $"Коробка передач: {car.Transmission.Name}\n" +
               $"Максимальная скорость: {car.MaxSpeed} км/ч\n" +
               $"Всего передач: {car.Gears}";
    }
    private IColor GetColorFromUser()
    {
        string colorMessage = "Выберите цвет автомобиля:\n" +
            "1 - Красный\n" +
            "2 - Синий\n" +
            "3 - Зеленый\n" +
            "4 - Черный\n" +
            "5 - Желтый\n" +
            "6 - Белый";

        int choice = GetUserChoice( colorMessage, 6 );
        return choice switch
        {
            1 => new RedColor(),
            2 => new BlueColor(),
            3 => new GreenColor(),
            4 => new BlackColor(),
            5 => new YellowColor(),
            6 => new WhiteColor(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    private IBodyType GetBodyTypeFromUser()
    {
        string bodyMessage = "Выберите тип кузова:\n" +
            "1 - Седан\n" +
            "2 - Внедорожник\n" +
            "3 - Хэтчбек\n" +
            "4 - Купе\n" +
            "5 - Кабриолет\n" +
            "6 - Минивэн";

        int choice = GetUserChoice( bodyMessage, 6 );
        return choice switch
        {
            1 => new Sedan(),
            2 => new SUV(),
            3 => new Hatchback(),
            4 => new Coupe(),
            5 => new Convertible(),
            6 => new Minivan(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    private IEngineType GetEngineTypeFromUser()
    {
        string engineMessage = "Выберите тип двигателя:\n" +
            "1 - V6\n" +
            "2 - V8\n" +
            "3 - Электрический\n" +
            "4 - Дизельный\n" +
            "5 - Гибридный\n" +
            "6 - Турбированный";

        int choice = GetUserChoice( engineMessage, 6 );
        return choice switch
        {
            1 => new V6(),
            2 => new V8(),
            3 => new Electric(),
            4 => new Diesel(),
            5 => new Hybrid(),
            6 => new Turbo(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    private ITransmissionType GetTransmissionTypeFromUser()
    {
        string transmissionMessage = "Выберите тип коробки передач:\n" +
            "1 - Механическая\n" +
            "2 - Автоматическая\n" +
            "3 - Полуавтоматическая\n" +
            "4 - CVT";

        int choice = GetUserChoice( transmissionMessage, 4 );
        return choice switch
        {
            1 => new Manual(),
            2 => new Automatic(),
            3 => new SemiAutomatic(),
            4 => new CVT(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    private int GetUserChoice( string message, int max )
    {
        Console.WriteLine( message );
        int choice;
        while ( !int.TryParse( Console.ReadLine(), out choice ) || choice < 1 || choice > max )
        {
            Console.WriteLine( "Неверный ввод. Пожалуйста, выберите число от 1 до " + max + "." );
        }
        return choice;
    }
}
