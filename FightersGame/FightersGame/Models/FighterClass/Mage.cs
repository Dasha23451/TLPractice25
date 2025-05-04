namespace Fighters.Models.FighterClass;
public class Mage : IFighterClass
{
    public string Name => "Маг";
    public int HealthBonus => 10;
    public int DamageBonus => 12;
    public int ArmorBonus => -2;
    public int InitiativeBonus => 3;
    public double CriticalChance => 0.25;
    public string SpecialAbility => "Магический щит (поглощает 20% урона)";
}