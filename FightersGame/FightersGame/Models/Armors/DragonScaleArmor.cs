namespace Fighters.Models.Armors;
public class DragonScaleArmor : BaseArmor
{
    public override string Name => "Драконий доспех";
    public override int ArmorValue => 20;
    public override string SpecialEffect => "Блокирует 30% урона";

    public override int CalculateDamageReduction( int incomingDamage )
    {
        return incomingDamage * 2 / 3;
    }
}
