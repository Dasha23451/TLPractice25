using Fighters.Models.Races;

namespace FighterGameTests.ModelsTests.Races;
public class DemonTests
{
    private readonly Demon _demon;

    public DemonTests()
    {
        _demon = new Demon();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Демон";

        // Act
        var actualName = _demon.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void Health_WhenCalled_ReturnsCorrectHealth()
    {
        // Arrange
        var expectedHealth = 85;

        // Act
        var actualHealth = _demon.Health;

        // Assert
        Assert.Equal( expectedHealth, actualHealth );
    }

    [Fact]
    public void Damage_WhenCalled_ReturnsCorrectDamage()
    {
        // Arrange
        var expectedDamage = 10;

        // Act
        var actualDamage = _demon.Damage;

        // Assert
        Assert.Equal( expectedDamage, actualDamage );
    }

    [Fact]
    public void Armor_WhenCalled_ReturnsCorrectArmor()
    {
        // Arrange
        var expectedArmor = 1;

        // Act
        var actualArmor = _demon.Armor;

        // Assert
        Assert.Equal( expectedArmor, actualArmor );
    }

    [Fact]
    public void Initiative_WhenCalled_ReturnsCorrectInitiative()
    {
        // Arrange
        var expectedInitiative = 7;

        // Act
        var actualInitiative = _demon.Initiative;

        // Assert
        Assert.Equal( expectedInitiative, actualInitiative );
    }
}