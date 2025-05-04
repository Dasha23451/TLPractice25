using Fighters.Models.Races;

namespace FighterGameTests.ModelsTests.Races;
public class UndeadTests
{
    private readonly Undead _undead;

    public UndeadTests()
    {
        _undead = new Undead();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Нежить";

        // Act
        var actualName = _undead.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void Health_WhenCalled_ReturnsCorrectHealth()
    {
        // Arrange
        var expectedHealth = 70;

        // Act
        var actualHealth = _undead.Health;

        // Assert
        Assert.Equal( expectedHealth, actualHealth );
    }

    [Fact]
    public void Damage_WhenCalled_ReturnsCorrectDamage()
    {
        // Arrange
        var expectedDamage = 6;

        // Act
        var actualDamage = _undead.Damage;

        // Assert
        Assert.Equal( expectedDamage, actualDamage );
    }

    [Fact]
    public void Armor_WhenCalled_ReturnsCorrectArmor()
    {
        // Arrange
        var expectedArmor = 0;

        // Act
        var actualArmor = _undead.Armor;

        // Assert
        Assert.Equal( expectedArmor, actualArmor );
    }

    [Fact]
    public void Initiative_WhenCalled_ReturnsCorrectInitiative()
    {
        // Arrange
        var expectedInitiative = 6;

        // Act
        var actualInitiative = _undead.Initiative;

        // Assert
        Assert.Equal( expectedInitiative, actualInitiative );
    }
}