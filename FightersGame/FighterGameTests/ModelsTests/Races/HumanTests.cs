using Fighters.Models.Races;

namespace FighterGameTests.ModelsTests.Races;
public class HumanTests
{
    private readonly Human _human;

    public HumanTests()
    {
        _human = new Human();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Человек";

        // Act
        var actualName = _human.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void Health_WhenCalled_ReturnsCorrectHealth()
    {
        // Arrange
        var expectedHealth = 100;

        // Act
        var actualHealth = _human.Health;

        // Assert
        Assert.Equal( expectedHealth, actualHealth );
    }

    [Fact]
    public void Damage_WhenCalled_ReturnsCorrectDamage()
    {
        // Arrange
        var expectedDamage = 5;

        // Act
        var actualDamage = _human.Damage;

        // Assert
        Assert.Equal( expectedDamage, actualDamage );
    }

    [Fact]
    public void Armor_WhenCalled_ReturnsCorrectArmor()
    {
        // Arrange
        var expectedArmor = 2;

        // Act
        var actualArmor = _human.Armor;

        // Assert
        Assert.Equal( expectedArmor, actualArmor );
    }

    [Fact]
    public void Initiative_WhenCalled_ReturnsCorrectInitiative()
    {
        // Arrange
        var expectedInitiative = 5;

        // Act
        var actualInitiative = _human.Initiative;

        // Assert
        Assert.Equal( expectedInitiative, actualInitiative );
    }
}