using CarFactory.EnumClass;

namespace CarFactory.Cars;
public static class CarsFactory
{
    public static ICar CreateCar( ColorCar color, BodyType body, EngineType engine, TransmissionType transmission )
    {
        return new Car( color, body, engine, transmission );
    }
}

