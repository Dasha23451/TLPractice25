using Fighters.Models.Weapons;

namespace FighterGameTests.ModelsTests.WeaponsTests;
public class StaffTests
{
    private readonly Staff _staff;

    public StaffTests()
    {
        _staff = new Staff();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Посох";

        // Act
        var actualName = _staff.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void Damage_WhenCalled_ReturnsCorrectDamage()
    {
        // Arrange
        var expectedDamage = 6;

        // Act
        var actualDamage = _staff.Damage;

        // Assert
        Assert.Equal( expectedDamage, actualDamage );
    }

    [Fact]
    public void Range_WhenCalled_ReturnsCorrectCritChance()
    {
        // Arrange
        var expectedCritChance = 2;

        // Act
        var actualCritChance = _staff.CritChance;

        // Assert
        Assert.Equal( expectedCritChance, actualCritChance );
    }

    [Fact]
    public void Description_WhenCalled_ReturnsCorrectSpecialEffect()
    {
        // Arrange
        var expectedSpecialEffect = "";

        // Act
        var actualSpecialEffect = _staff.SpecialEffect;

        // Assert
        Assert.Equal( expectedSpecialEffect, actualSpecialEffect );
    }

    [Fact]
    public void Rarity_WhenCalled_ReturnsCorrectRarity()
    {
        // Arrange
        var expectedRarity = Rarity.Common;

        // Act
        var actualRarity = _staff.Rarity;

        // Assert
        Assert.Equal( expectedRarity, actualRarity );
    }
}