using Fighters.Models.FighterClass;

namespace FighterGameTests.ModelsTests.FighterClassTests;
public class BerserkerTests
{
    private readonly Berserker _berserker;

    public BerserkerTests()
    {
        _berserker = new Berserker();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Берсерк";

        // Act
        var actualName = _berserker.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void HealthBonus_WhenCalled_ReturnsCorrectHealthBonus()
    {
        // Arrange
        var expectedHealthBonus = 30;

        // Act
        var actualHealthBonus = _berserker.HealthBonus;

        // Assert
        Assert.Equal( expectedHealthBonus, actualHealthBonus );
    }

    [Fact]
    public void DamageBonus_WhenCalled_ReturnsCorrectDamageBonus()
    {
        // Arrange
        var expectedDamageBonus = 10;

        // Act
        var actualDamageBonus = _berserker.DamageBonus;

        // Assert
        Assert.Equal( expectedDamageBonus, actualDamageBonus );
    }

    [Fact]
    public void ArmorBonus_WhenCalled_ReturnsCorrectArmorBonus()
    {
        // Arrange
        var expectedArmorBonus = 0;

        // Act
        var actualArmorBonus = _berserker.ArmorBonus;

        // Assert
        Assert.Equal( expectedArmorBonus, actualArmorBonus );
    }

    [Fact]
    public void InitiativeBonus_WhenCalled_ReturnsCorrectInitiativeBonus()
    {
        // Arrange
        var expectedInitiativeBonus = 4;

        // Act
        var actualInitiativeBonus = _berserker.InitiativeBonus;

        // Assert
        Assert.Equal( expectedInitiativeBonus, actualInitiativeBonus );
    }

    [Fact]
    public void CriticalChance_WhenCalled_ReturnsCorrectCriticalChance()
    {
        // Arrange
        var expectedCriticalChance = 0.20;

        // Act
        var actualCriticalChance = _berserker.CriticalChance;

        // Assert
        Assert.Equal( expectedCriticalChance, actualCriticalChance );
    }

    [Fact]
    public void SpecialAbility_WhenCalled_ReturnsCorrectSpecialAbility()
    {
        // Arrange
        var expectedSpecialAbility = "Ярость (при здоровье <30% урон +30%)";

        // Act
        var actualSpecialAbility = _berserker.SpecialAbility;

        // Assert
        Assert.Equal( expectedSpecialAbility, actualSpecialAbility );
    }
}