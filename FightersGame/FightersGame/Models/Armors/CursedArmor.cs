namespace Fighters.Models.Armors;
public class CursedArmor : BaseArmor
{
    public override string Name => "Проклятая броня";
    public override int ArmorValue => 25;
    public override string SpecialEffect => "Постепенно уменьшает здоровье владельца";
    public override int CalculateDamageReduction( int incomingDamage )
    {
        return base.CalculateDamageReduction( incomingDamage ) + 10;
    }
}