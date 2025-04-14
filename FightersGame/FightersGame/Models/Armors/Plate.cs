namespace Fighters.Models.Armors;
public class Plate : BaseArmor
{
    public override string Name => "Латы";
    public override int ArmorValue => 22;
    public override string SpecialEffect => "Блокирует 10% урона";
    public override int CalculateDamageReduction( int incomingDamage )
    {
        return base.CalculateDamageReduction( incomingDamage ) * 10 / 100;
    }
}