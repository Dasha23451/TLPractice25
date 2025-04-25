namespace Fighters.Models.Armors;
public class LeatherArmor : BaseArmor
{
    public override string Name => "Кожаная броня";
    public override int ArmorValue => 8;
    public override string SpecialEffect => "+10% к уклонению";
    public override int CalculateDamageReduction( int incomingDamage )
    {
        return new Random().Next( 100 ) < 10 ? 0 : incomingDamage;
    }
}