namespace Fighters.Models.FighterClass;
public class Knight : IFighterClass
{
    public string Name => "Рыцарь";
    public int HealthBonus => 50;
    public int DamageBonus => 5;
    public int ArmorBonus => 3;
    public int InitiativeBonus => 2;
    public double CriticalChance => 0.10;
    public string SpecialAbility => "Блок щитом (шанс 25% уменьшить урон на 50%)";
}
