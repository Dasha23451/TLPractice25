namespace Fighters.Models.Armors;
public class ScaleMail : BaseArmor
{
    public override string Name => "Чешуйчатый доспех";
    public override int ArmorValue => 15;
    public override string SpecialEffect => "-20% крит урон";

    public override int CalculateDamageReduction( int incomingDamage )
    {
        return Math.Abs( base.CalculateDamageReduction( incomingDamage ) ) * 8 / 10;
    }
}
