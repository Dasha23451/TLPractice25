using Fighters.Models.Weapons;

namespace FighterGameTests.ModelsTests.WeaponsTests;
public class AxeTests
{
    private readonly Axe _axe;

    public AxeTests()
    {
        _axe = new Axe();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Топор";

        // Act
        var actualName = _axe.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void Damage_WhenCalled_ReturnsCorrectDamage()
    {
        // Arrange
        var expectedDamage = 12;

        // Act
        var actualDamage = _axe.Damage;

        // Assert
        Assert.Equal( expectedDamage, actualDamage );
    }

    [Fact]
    public void CritChance_WhenCalled_ReturnsCorrectCritChance()
    {
        // Arrange
        var expectedCritChance = 5;

        // Act
        var actualCritChance = _axe.CritChance;

        // Assert
        Assert.Equal( expectedCritChance, actualCritChance );
    }

    [Fact]
    public void SpecialEffect_WhenCalled_ReturnsCorrectSpecialEffect()
    {
        // Arrange
        var expectedSpecialEffect = "";

        // Act
        var actualSpecialEffect = _axe.SpecialEffect;

        // Assert
        Assert.Equal( expectedSpecialEffect, actualSpecialEffect );
    }

    [Fact]
    public void Rarity_WhenCalled_ReturnsCorrectRarity()
    {
        // Arrange
        var expectedRarity = Rarity.Common;

        // Act
        var actualRarity = _axe.Rarity;

        // Assert
        Assert.Equal( expectedRarity, actualRarity );
    }
}