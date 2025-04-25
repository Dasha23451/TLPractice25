using CarFactory.Cars;

namespace CarFactory;
public class CarController
{
    CarsFactory _generatedCar = new CarsFactory();
    public void Start()
    {
        ICar car = _generatedCar.Generate();
        string configuration = _generatedCar.GetCarConfiguration( car );
        Console.WriteLine( configuration );
    }
}
