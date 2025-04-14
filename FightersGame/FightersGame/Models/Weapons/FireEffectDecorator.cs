namespace Fighters.Models.Weapons;
public class FireEffectDecorator : WeaponDecorator
{
    public FireEffectDecorator( IWeapon weapon ) : base( weapon ) { }

    public override int Damage => base.Damage + 5;
}