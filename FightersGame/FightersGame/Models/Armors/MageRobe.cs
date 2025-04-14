namespace Fighters.Models.Armors;
public class MageRobe : BaseArmor
{
    public override string Name => "Мантия мага";
    public override int ArmorValue => 5;
    public override string SpecialEffect => "+20% маг.защита";
    public override int CalculateDamageReduction( int incomingDamage )
    {
        return incomingDamage * 3 / 4;
    }
}