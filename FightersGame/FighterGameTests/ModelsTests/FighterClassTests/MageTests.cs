using Fighters.Models.FighterClass;

namespace FighterGameTests.ModelsTests.FighterClassTests;
public class MageTests
{
    private readonly Mage _mage;

    public MageTests()
    {
        _mage = new Mage();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Маг";

        // Act
        var actualName = _mage.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void HealthBonus_WhenCalled_ReturnsCorrectHealthBonus()
    {
        // Arrange
        var expectedHealthBonus = 10;

        // Act
        var actualHealthBonus = _mage.HealthBonus;

        // Assert
        Assert.Equal( expectedHealthBonus, actualHealthBonus );
    }

    [Fact]
    public void DamageBonus_WhenCalled_ReturnsCorrectDamageBonus()
    {
        // Arrange
        var expectedDamageBonus = 12;

        // Act
        var actualDamageBonus = _mage.DamageBonus;

        // Assert
        Assert.Equal( expectedDamageBonus, actualDamageBonus );
    }

    [Fact]
    public void ArmorBonus_WhenCalled_ReturnsCorrectArmorBonus()
    {
        // Arrange
        var expectedArmorBonus = -2;

        // Act
        var actualArmorBonus = _mage.ArmorBonus;

        // Assert
        Assert.Equal( expectedArmorBonus, actualArmorBonus );
    }

    [Fact]
    public void InitiativeBonus_WhenCalled_ReturnsCorrectInitiativeBonus()
    {
        // Arrange
        var expectedInitiativeBonus = 3;

        // Act
        var actualInitiativeBonus = _mage.InitiativeBonus;

        // Assert
        Assert.Equal( expectedInitiativeBonus, actualInitiativeBonus );
    }

    [Fact]
    public void CriticalChance_WhenCalled_ReturnsCorrectCriticalChance()
    {
        // Arrange
        var expectedCriticalChance = 0.25;

        // Act
        var actualCriticalChance = _mage.CriticalChance;

        // Assert
        Assert.Equal( expectedCriticalChance, actualCriticalChance );
    }

    [Fact]
    public void SpecialAbility_WhenCalled_ReturnsCorrectSpecialAbility()
    {
        // Arrange
        var expectedSpecialAbility = "Магический щит (поглощает 20% урона)";

        // Act
        var actualSpecialAbility = _mage.SpecialAbility;

        // Assert
        Assert.Equal( expectedSpecialAbility, actualSpecialAbility );
    }
}