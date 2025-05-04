using System;

namespace Fighters.Models.Armors;
public class LeatherArmor : BaseArmor
{
    public override string Name => "Кожаная броня";
    public override int ArmorValue => 8;
    public override string SpecialEffect => "+10% к уклонению";
    private readonly Random _random;
    public LeatherArmor() : this( null ) { }
    public LeatherArmor( Random random )
    {
        _random = random ?? new Random();
    }

    public override int CalculateDamageReduction( int incomingDamage )
    {
        return _random.Next( 100 ) < 10 ? 0 : incomingDamage;
    }
}