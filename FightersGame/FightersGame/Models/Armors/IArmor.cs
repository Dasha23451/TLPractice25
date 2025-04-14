namespace Fighters.Models.Armors;
public interface IArmor
{
    public string Name { get; }
    public int ArmorValue { get; }
    public int Durability { get; }
    public string SpecialEffect { get; }
    public int CalculateDamageReduction( int incomingDamage );
}
