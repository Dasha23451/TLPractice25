using CarFactory.Cars;
using CarFactory.Color;
using CarFactory.BodyType;
using CarFactory.EngineType;
using CarFactory.TransmissionType;

public class Car : ICar
{
    public IColor Color { get; }
    public IBodyType Body { get; }
    public IEngineType Engine { get; }
    public ITransmissionType Transmission { get; }
    public int MaxSpeed => Engine.Speed;
    public int Gears => Transmission.Transmission;

    public Car( IColor color, IBodyType body, IEngineType engine, ITransmissionType transmission )
    {
        Color = color;
        Body = body;
        Engine = engine;
        Transmission = transmission;
    }

    public string GetConfiguration()
    {
        return $"Цвет: {Color.Name}, Кузов: {Body.Name}, Двигатель: {Engine.Name}, Коробка передач: {Transmission.Name}, Максимальная скорость: {MaxSpeed} км/ч, Всего передач: {Gears}";
    }
}
