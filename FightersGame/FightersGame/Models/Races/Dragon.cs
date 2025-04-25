namespace Fighters.Models.Races;
public class Dragon : IRace
{
    public string Name => "Дракон";
    public int Health => 125;
    public int Damage => 9;
    public int Armor => 6;
    public int Initiative => 4;
}
