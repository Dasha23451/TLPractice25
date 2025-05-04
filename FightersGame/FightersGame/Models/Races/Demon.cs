namespace Fighters.Models.Races;
public class Demon : IRace
{
    public string Name => "Демон";
    public int Health => 85;
    public int Damage => 10;
    public int Armor => 1;
    public int Initiative => 7;
}
