using CarFactory.Color;
using CarFactory.BodyType;
using CarFactory.EngineType;
using CarFactory.TransmissionType;

namespace CarFactory.Cars
{
    public interface ICar
    {
        IColor Color { get; }
        IBodyType Body { get; }
        IEngineType Engine { get; }
        ITransmissionType Transmission { get; }
        int MaxSpeed { get; }
        int Gears { get; }
        string GetConfiguration();
    }
}
