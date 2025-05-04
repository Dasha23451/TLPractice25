using Fighters.Models.Races;

namespace FighterGameTests.ModelsTests.Races;
public class ElfTests
{
    private readonly Elf _elf;

    public ElfTests()
    {
        _elf = new Elf();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Эльф";

        // Act
        var actualName = _elf.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void Health_WhenCalled_ReturnsCorrectHealth()
    {
        // Arrange
        var expectedHealth = 80;

        // Act
        var actualHealth = _elf.Health;

        // Assert
        Assert.Equal( expectedHealth, actualHealth );
    }

    [Fact]
    public void Damage_WhenCalled_ReturnsCorrectDamage()
    {
        // Arrange
        var expectedDamage = 7;

        // Act
        var actualDamage = _elf.Damage;

        // Assert
        Assert.Equal( expectedDamage, actualDamage );
    }

    [Fact]
    public void Armor_WhenCalled_ReturnsCorrectArmor()
    {
        // Arrange
        var expectedArmor = 1;

        // Act
        var actualArmor = _elf.Armor;

        // Assert
        Assert.Equal( expectedArmor, actualArmor );
    }

    [Fact]
    public void Initiative_WhenCalled_ReturnsCorrectInitiative()
    {
        // Arrange
        var expectedInitiative = 8;

        // Act
        var actualInitiative = _elf.Initiative;

        // Assert
        Assert.Equal( expectedInitiative, actualInitiative );
    }
}