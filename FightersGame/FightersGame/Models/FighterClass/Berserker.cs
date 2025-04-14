namespace Fighters.Models.FighterClass;
public class Berserker : IFighterClass
{
    public string Name => "Берсерк";
    public int HealthBonus => 30;
    public int DamageBonus => 10;
    public int ArmorBonus => 0;
    public int InitiativeBonus => 4;
    public double CriticalChance => 0.20;
    public string SpecialAbility => "Ярость (при здоровье <30% урон +30%)";
}