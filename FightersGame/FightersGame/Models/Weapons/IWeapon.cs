namespace Fighters.Models.Weapons;
public interface IWeapon
{
    public string Name { get; }
    public int Damage { get; }
    public int CritChance { get; }
    public string SpecialEffect { get; }
    public Rarity Rarity { get; }

}
