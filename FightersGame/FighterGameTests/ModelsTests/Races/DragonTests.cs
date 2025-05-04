using Fighters.Models.Races;

namespace FighterGameTests.ModelsTests.Races;
public class DragonTests
{
    private readonly Dragon _dragon;

    public DragonTests()
    {
        _dragon = new Dragon();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Дракон";

        // Act
        var actualName = _dragon.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void Health_WhenCalled_ReturnsCorrectHealth()
    {
        // Arrange
        var expectedHealth = 125;

        // Act
        var actualHealth = _dragon.Health;

        // Assert
        Assert.Equal( expectedHealth, actualHealth );
    }

    [Fact]
    public void Damage_WhenCalled_ReturnsCorrectDamage()
    {
        // Arrange
        var expectedDamage = 9;

        // Act
        var actualDamage = _dragon.Damage;

        // Assert
        Assert.Equal( expectedDamage, actualDamage );
    }

    [Fact]
    public void Armor_WhenCalled_ReturnsCorrectArmor()
    {
        // Arrange
        var expectedArmor = 6;

        // Act
        var actualArmor = _dragon.Armor;

        // Assert
        Assert.Equal( expectedArmor, actualArmor );
    }

    [Fact]
    public void Initiative_WhenCalled_ReturnsCorrectInitiative()
    {
        // Arrange
        var expectedInitiative = 4;

        // Act
        var actualInitiative = _dragon.Initiative;

        // Assert
        Assert.Equal( expectedInitiative, actualInitiative );
    }
}