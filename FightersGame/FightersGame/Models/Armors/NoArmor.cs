namespace Fighters.Models.Armors;

public class NoArmor : BaseArmor
{
    public override string Name => "Без брони";
    public override int ArmorValue => 0;
    public override string SpecialEffect => "+15% к уклонению";
    public override int CalculateDamageReduction( int incomingDamage )
    {
        return new Random().Next( 100 ) < 15 ? 0 : incomingDamage;
    }
}
