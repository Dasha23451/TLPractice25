namespace Fighters.Models.Weapons;
public class LifestealDecorator : WeaponDecorator
{
    public int LifestealPercent { get; }
    public LifestealDecorator( IWeapon weapon, int lifestealPercent ) : base( weapon )
    {
        LifestealPercent = lifestealPercent;
    }
    public override string SpecialEffect => base.SpecialEffect + $", Кража здоровья {LifestealPercent}%";
}
