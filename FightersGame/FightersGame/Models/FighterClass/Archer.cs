namespace Fighters.Models.FighterClass;
public class Archer : IFighterClass
{
    public string Name => "Лучник";
    public int HealthBonus => 20;
    public int DamageBonus => 8;
    public int ArmorBonus => 1;
    public int InitiativeBonus => 6;
    public double CriticalChance => 0.15;
    public string SpecialAbility => "Меткий выстрел (шанс 15% на двойной урон)";
}
