namespace Fighters.Models.Fighter;
public interface IFighter
{
    public string Name { get; }
    public int CurrentHealth { get; }
    public int MaxHealth { get; }
    public int TotalPower { get; }
    public int TotalArmor { get; }
    public int Initiative { get; }
    public bool IsAlive { get; }

    void Attack( IFighter target );
    void TakeDamage( int damage );
    void DisplayStats();
}


