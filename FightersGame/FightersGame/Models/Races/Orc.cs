namespace Fighters.Models.Races;
public class Orc : IRace
{
    public string Name => "Орк";
    public int Health => 120;
    public int Damage => 8;
    public int Armor => 3;
    public int Initiative => 3;
}
