using System;

namespace Fighters.Models.Armors;

public class NoArmor : BaseArmor
{
    public override string Name => "Без брони";
    public override int ArmorValue => 0;
    public override string SpecialEffect => "+15% к уклонению";
    private readonly Random _random;
    public NoArmor() : this( null ) { }
    public NoArmor( Random random )
    {
        _random = random ?? new Random();
    }
    public override int CalculateDamageReduction( int incomingDamage )
    {
        return _random.Next( 100 ) < 15 ? 0 : incomingDamage;
    }
}
