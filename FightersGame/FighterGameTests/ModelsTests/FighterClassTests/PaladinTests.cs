using Fighters.Models.FighterClass;

namespace FighterGameTests.ModelsTests.FighterClassTests;
public class PaladinTests
{
    private readonly Paladin _paladin;

    public PaladinTests()
    {
        _paladin = new Paladin();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Паладин";

        // Act
        var actualName = _paladin.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void HealthBonus_WhenCalled_ReturnsCorrectHealthBonus()
    {
        // Arrange
        var expectedHealthBonus = 60;

        // Act
        var actualHealthBonus = _paladin.HealthBonus;

        // Assert
        Assert.Equal( expectedHealthBonus, actualHealthBonus );
    }

    [Fact]
    public void DamageBonus_WhenCalled_ReturnsCorrectDamageBonus()
    {
        // Arrange
        var expectedDamageBonus = 6;

        // Act
        var actualDamageBonus = _paladin.DamageBonus;

        // Assert
        Assert.Equal( expectedDamageBonus, actualDamageBonus );
    }

    [Fact]
    public void ArmorBonus_WhenCalled_ReturnsCorrectArmorBonus()
    {
        // Arrange
        var expectedArmorBonus = 5;

        // Act
        var actualArmorBonus = _paladin.ArmorBonus;

        // Assert
        Assert.Equal( expectedArmorBonus, actualArmorBonus );
    }

    [Fact]
    public void InitiativeBonus_WhenCalled_ReturnsCorrectInitiativeBonus()
    {
        // Arrange
        var expectedInitiativeBonus = 1;

        // Act
        var actualInitiativeBonus = _paladin.InitiativeBonus;

        // Assert
        Assert.Equal( expectedInitiativeBonus, actualInitiativeBonus );
    }

    [Fact]
    public void CriticalChance_WhenCalled_ReturnsCorrectCriticalChance()
    {
        // Arrange
        var expectedCriticalChance = 0.08;

        // Act
        var actualCriticalChance = _paladin.CriticalChance;

        // Assert
        Assert.Equal( expectedCriticalChance, actualCriticalChance );
    }

    [Fact]
    public void SpecialAbility_WhenCalled_ReturnsCorrectSpecialAbility()
    {
        // Arrange
        var expectedSpecialAbility = "Божественное исцеление (восстанавливает 10% здоровья за ход)";

        // Act
        var actualSpecialAbility = _paladin.SpecialAbility;

        // Assert
        Assert.Equal( expectedSpecialAbility, actualSpecialAbility );
    }
}