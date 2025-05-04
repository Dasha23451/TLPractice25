namespace Fighters.Models.FighterClass;
public class Rogue : IFighterClass
{
    public string Name => "Разбойник";
    public int HealthBonus => 25;
    public int DamageBonus => 7;
    public int ArmorBonus => 2;
    public int InitiativeBonus => 8;
    public double CriticalChance => 0.30;
    public string SpecialAbility => "Скрытая атака (первый удар в бою всегда критический)";
}