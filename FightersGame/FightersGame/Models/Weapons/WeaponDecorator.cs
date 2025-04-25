namespace Fighters.Models.Weapons;
public abstract class WeaponDecorator : IWeapon
{
    public IWeapon Weapon;

    public WeaponDecorator( IWeapon weapon )
    {
        Weapon = weapon;
    }

    public virtual string Name => Weapon.Name;
    public virtual int Damage => Weapon.Damage;
    public virtual int CritChance => Weapon.CritChance;
    public virtual string SpecialEffect => Weapon.SpecialEffect;
    public virtual Rarity Rarity => Weapon.Rarity;
}
