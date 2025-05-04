namespace Fighters.Models.FighterClass;
public class Paladin : IFighterClass
{
    public string Name => "Паладин";
    public int HealthBonus => 60;
    public int DamageBonus => 6;
    public int ArmorBonus => 5;
    public int InitiativeBonus => 1;
    public double CriticalChance => 0.08;
    public string SpecialAbility => "Божественное исцеление (восстанавливает 10% здоровья за ход)";
}
