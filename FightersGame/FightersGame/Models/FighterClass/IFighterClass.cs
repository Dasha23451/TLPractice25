namespace Fighters.Models.FighterClass;
public interface IFighterClass
{
    public string Name { get; }
    public int HealthBonus { get; }
    public int DamageBonus { get; }
    public int ArmorBonus { get; }
    public int InitiativeBonus { get; }
    public double CriticalChance { get; }
    public string SpecialAbility { get; }

}
