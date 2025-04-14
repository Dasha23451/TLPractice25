using CarFactory.Cars;
using CarFactory.EnumClass;

public class Car : ICar
{
    public ColorCar Color { get; }
    public BodyType Body { get; }
    public EngineType Engine { get; }
    public TransmissionType Transmission { get; }

    public int MaxSpeed { get; }
    public int Gears { get; }

    public Car( ColorCar color, BodyType body, EngineType engine, TransmissionType transmission )
    {
        Color = color;
        Body = body;
        Engine = engine;
        Transmission = transmission;

        MaxSpeed = engine switch
        {
            EngineType.V6 => 180,
            EngineType.V8 => 220,
            EngineType.Electric => 200,
            EngineType.Diesel => 160,
            EngineType.Hybrid => 190,
            EngineType.Turbo => 210,
            _ => 0
        };

        Gears = transmission switch
        {
            TransmissionType.Manual => 6,
            TransmissionType.Automatic => 8,
            TransmissionType.SemiAutomatic => 7,
            TransmissionType.CVT => 1,
            _ => 0
        };
    }

    public string GetConfiguration()
    {
        return $"Цвет: {Color}, Кузов: {Body}, Двигатель: {Engine}, Коробка передач: {Transmission}, Максимальная скорость: {MaxSpeed} км/ч, Всего передач: {Gears}";
    }
}
