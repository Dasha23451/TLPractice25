namespace CarFactory.Cars;
public interface ICar
{
    int MaxSpeed { get; }
    int Gears { get; }
    string GetConfiguration();
}
