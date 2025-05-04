using Fighters.Models.Races;

namespace FighterGameTests.ModelsTests.Races;
public class AngelTests
{
    private readonly Angel _angel;

    public AngelTests()
    {
        _angel = new Angel();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Ангел";

        // Act
        var actualName = _angel.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void Health_WhenCalled_ReturnsCorrectHealth()
    {
        // Arrange
        var expectedHealth = 110;

        // Act
        var actualHealth = _angel.Health;

        // Assert
        Assert.Equal( expectedHealth, actualHealth );
    }

    [Fact]
    public void Damage_WhenCalled_ReturnsCorrectDamage()
    {
        // Arrange
        var expectedDamage = 7;

        // Act
        var actualDamage = _angel.Damage;

        // Assert
        Assert.Equal( expectedDamage, actualDamage );
    }

    [Fact]
    public void Armor_WhenCalled_ReturnsCorrectArmor()
    {
        // Arrange
        var expectedArmor = 4;

        // Act
        var actualArmor = _angel.Armor;

        // Assert
        Assert.Equal( expectedArmor, actualArmor );
    }

    [Fact]
    public void Initiative_WhenCalled_ReturnsCorrectInitiative()
    {
        // Arrange
        var expectedInitiative = 6;

        // Act
        var actualInitiative = _angel.Initiative;

        // Assert
        Assert.Equal( expectedInitiative, actualInitiative );
    }
}