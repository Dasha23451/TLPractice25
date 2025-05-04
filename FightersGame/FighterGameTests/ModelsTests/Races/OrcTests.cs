using Fighters.Models.Races;

namespace FighterGameTests.ModelsTests.Races;
public class OrcTests
{
    private readonly Orc _orc;

    public OrcTests()
    {
        _orc = new Orc();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Орк";

        // Act
        var actualName = _orc.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void Health_WhenCalled_ReturnsCorrectHealth()
    {
        // Arrange
        var expectedHealth = 120;

        // Act
        var actualHealth = _orc.Health;

        // Assert
        Assert.Equal( expectedHealth, actualHealth );
    }

    [Fact]
    public void Damage_WhenCalled_ReturnsCorrectDamage()
    {
        // Arrange
        var expectedDamage = 8;

        // Act
        var actualDamage = _orc.Damage;

        // Assert
        Assert.Equal( expectedDamage, actualDamage );
    }

    [Fact]
    public void Armor_WhenCalled_ReturnsCorrectArmor()
    {
        // Arrange
        var expectedArmor = 3;

        // Act
        var actualArmor = _orc.Armor;

        // Assert
        Assert.Equal( expectedArmor, actualArmor );
    }

    [Fact]
    public void Initiative_WhenCalled_ReturnsCorrectInitiative()
    {
        // Arrange
        var expectedInitiative = 3;

        // Act
        var actualInitiative = _orc.Initiative;

        // Assert
        Assert.Equal( expectedInitiative, actualInitiative );
    }
}