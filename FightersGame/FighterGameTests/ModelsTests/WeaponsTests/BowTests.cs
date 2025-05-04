using Fighters.Models.Weapons;

namespace FighterGameTests.ModelsTests.WeaponsTests;
public class BowTests
{
    private readonly Bow _bow;

    public BowTests()
    {
        _bow = new Bow();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Лук";

        // Act
        var actualName = _bow.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void Damage_WhenCalled_ReturnsCorrectDamage()
    {
        // Arrange
        var expectedDamage = 8;

        // Act
        var actualDamage = _bow.Damage;

        // Assert
        Assert.Equal( expectedDamage, actualDamage );
    }

    [Fact]
    public void CritChance_WhenCalled_ReturnsCorrectCritChance()
    {
        // Arrange
        var expectedCritChance = 10;

        // Act
        var actualCritChance = _bow.CritChance;

        // Assert
        Assert.Equal( expectedCritChance, actualCritChance );
    }

    [Fact]
    public void SpecialEffect_WhenCalled_ReturnsCorrectSpecialEffect()
    {
        // Arrange
        var expectedSpecialEffect = "";

        // Act
        var actualSpecialEffect = _bow.SpecialEffect;

        // Assert
        Assert.Equal( expectedSpecialEffect, actualSpecialEffect );
    }

    [Fact]
    public void Rarity_WhenCalled_ReturnsCorrectRarity()
    {
        // Arrange
        var expectedRarity = Rarity.Common;

        // Act
        var actualRarity = _bow.Rarity;

        // Assert
        Assert.Equal( expectedRarity, actualRarity );
    }
}