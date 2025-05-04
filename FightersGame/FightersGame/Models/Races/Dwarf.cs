namespace Fighters.Models.Races;
public class Dwarf : IRace
{
    public string Name => "Гном";
    public int Health => 90;
    public int Damage => 6;
    public int Armor => 5;
    public int Initiative => 4;
}
