namespace Fighters.Models.Weapons;
public abstract class Weapon : IWeapon
{
    public string Name { get; }
    public int Damage { get; }
    public int CritChance { get; }
    public string SpecialEffect { get; }
    public Rarity Rarity { get; }

    protected Weapon( string name, int damage, int critChance = 10, string effect = "", Rarity rarity = Rarity.Common )
    {
        Name = name;
        Damage = damage;
        CritChance = critChance;
        SpecialEffect = effect;
        Rarity = rarity;
    }
}

public enum Rarity
{
    Common,
    Rare,
    Epic
}
