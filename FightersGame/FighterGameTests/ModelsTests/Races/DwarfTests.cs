using Fighters.Models.Races;

namespace FighterGameTests.ModelsTests.Races;
public class DwarfTests
{
    private readonly Dwarf _dwarf;

    public DwarfTests()
    {
        _dwarf = new Dwarf();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Гном";

        // Act
        var actualName = _dwarf.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void Health_WhenCalled_ReturnsCorrectHealth()
    {
        // Arrange
        var expectedHealth = 90;

        // Act
        var actualHealth = _dwarf.Health;

        // Assert
        Assert.Equal( expectedHealth, actualHealth );
    }

    [Fact]
    public void Damage_WhenCalled_ReturnsCorrectDamage()
    {
        // Arrange
        var expectedDamage = 6;

        // Act
        var actualDamage = _dwarf.Damage;

        // Assert
        Assert.Equal( expectedDamage, actualDamage );
    }

    [Fact]
    public void Armor_WhenCalled_ReturnsCorrectArmor()
    {
        // Arrange
        var expectedArmor = 5;

        // Act
        var actualArmor = _dwarf.Armor;

        // Assert
        Assert.Equal( expectedArmor, actualArmor );
    }

    [Fact]
    public void Initiative_WhenCalled_ReturnsCorrectInitiative()
    {
        // Arrange
        var expectedInitiative = 4;

        // Act
        var actualInitiative = _dwarf.Initiative;

        // Assert
        Assert.Equal( expectedInitiative, actualInitiative );
    }
}
