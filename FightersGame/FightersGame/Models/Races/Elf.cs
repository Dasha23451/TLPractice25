namespace Fighters.Models.Races;
public class Elf : IRace
{
    public string Name => "Эльф";
    public int Health => 80;
    public int Damage => 7;
    public int Armor => 1;
    public int Initiative => 8;
}
