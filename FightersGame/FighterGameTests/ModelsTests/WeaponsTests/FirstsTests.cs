using Fighters.Models.Weapons;

namespace FighterGameTests.ModelsTests.WeaponsTests;
public class FirstsTests
{
    private readonly Firsts _firsts;

    public FirstsTests()
    {
        _firsts = new Firsts();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Кулаки";

        // Act
        var actualName = _firsts.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void Damage_WhenCalled_ReturnsCorrectDamage()
    {
        // Arrange
        var expectedDamage = 1;

        // Act
        var actualDamage = _firsts.Damage;

        // Assert
        Assert.Equal( expectedDamage, actualDamage );
    }

    [Fact]
    public void CritChance_WhenCalled_ReturnsCorrectCritChance()
    {
        // Arrange
        var expectedCritChance = 0;

        // Act
        var actualCritChance = _firsts.CritChance;

        // Assert
        Assert.Equal( expectedCritChance, actualCritChance );
    }

    [Fact]
    public void SpecialEffect_WhenCalled_ReturnsCorrectSpecialEffect()
    {
        // Arrange
        var expectedSpecialEffect = "";

        // Act
        var actualSpecialEffect = _firsts.SpecialEffect;

        // Assert
        Assert.Equal( expectedSpecialEffect, actualSpecialEffect );
    }

    [Fact]
    public void Rarity_WhenCalled_ReturnsCorrectRarity()
    {
        // Arrange
        var expectedRarity = Rarity.Common;

        // Act
        var actualRarity = _firsts.Rarity;

        // Assert
        Assert.Equal( expectedRarity, actualRarity );
    }
}