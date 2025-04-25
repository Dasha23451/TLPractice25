namespace Fighters.Models.Armors;
public abstract class BaseArmor : IArmor
{
    public abstract string Name { get; }
    public abstract int ArmorValue { get; }
    public virtual int Durability => 100;
    public virtual string SpecialEffect => "Нет";

    public virtual int CalculateDamageReduction( int incomingDamage )
    {
        double reduction = ArmorValue * 0.05;
        return ( int )( incomingDamage * ( 1 - reduction ) );
    }
}