namespace Fighters.Models.Races;
public class Undead : IRace
{
    public string Name => "Нежить";
    public int Health => 70;
    public int Damage => 6;
    public int Armor => 0;
    public int Initiative => 6;
}
