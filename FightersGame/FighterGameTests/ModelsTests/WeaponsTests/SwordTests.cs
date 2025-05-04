using Fighters.Models.Weapons;

namespace FighterGameTests.ModelsTests.WeaponsTests;
public class SwordTests
{
    private readonly Sword _sword;

    public SwordTests()
    {
        _sword = new Sword();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Меч";

        // Act
        var actualName = _sword.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void Damage_WhenCalled_ReturnsCorrectDamage()
    {
        // Arrange
        var expectedDamage = 10;

        // Act
        var actualDamage = _sword.Damage;

        // Assert
        Assert.Equal( expectedDamage, actualDamage );
    }

    [Fact]
    public void CritChance_WhenCalled_ReturnsCorrectCritChance()
    {
        // Arrange
        var expectedCritChance = 5;

        // Act
        var actualCritChance = _sword.CritChance;

        // Assert
        Assert.Equal( expectedCritChance, actualCritChance );
    }

    [Fact]
    public void SpecialEffect_WhenCalled_ReturnsCorrectSpecialEffect()
    {
        // Arrange
        var expectedSpecialEffect = "";

        // Act
        var actualSpecialEffect = _sword.SpecialEffect;

        // Assert
        Assert.Equal( expectedSpecialEffect, actualSpecialEffect );
    }

    [Fact]
    public void Rarity_WhenCalled_ReturnsCorrectRarity()
    {
        // Arrange
        var expectedRarity = Rarity.Common;

        // Act
        var actualRarity = _sword.Rarity;

        // Assert
        Assert.Equal( expectedRarity, actualRarity );
    }
}