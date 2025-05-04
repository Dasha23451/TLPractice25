using Fighters.Models.FighterClass;

namespace FighterGameTests.ModelsTests.FighterClassTests;
public class KnightTests
{
    private readonly Knight _knight;

    public KnightTests()
    {
        _knight = new Knight();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Рыцарь";

        // Act
        var actualName = _knight.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void HealthBonus_WhenCalled_ReturnsCorrectHealthBonus()
    {
        // Arrange
        var expectedHealthBonus = 50;

        // Act
        var actualHealthBonus = _knight.HealthBonus;

        // Assert
        Assert.Equal( expectedHealthBonus, actualHealthBonus );
    }

    [Fact]
    public void DamageBonus_WhenCalled_ReturnsCorrectDamageBonus()
    {
        // Arrange
        var expectedDamageBonus = 5;

        // Act
        var actualDamageBonus = _knight.DamageBonus;

        // Assert
        Assert.Equal( expectedDamageBonus, actualDamageBonus );
    }

    [Fact]
    public void ArmorBonus_WhenCalled_ReturnsCorrectArmorBonus()
    {
        // Arrange
        var expectedArmorBonus = 3;

        // Act
        var actualArmorBonus = _knight.ArmorBonus;

        // Assert
        Assert.Equal( expectedArmorBonus, actualArmorBonus );
    }

    [Fact]
    public void InitiativeBonus_WhenCalled_ReturnsCorrectInitiativeBonus()
    {
        // Arrange
        var expectedInitiativeBonus = 2;

        // Act
        var actualInitiativeBonus = _knight.InitiativeBonus;

        // Assert
        Assert.Equal( expectedInitiativeBonus, actualInitiativeBonus );
    }

    [Fact]
    public void CriticalChance_WhenCalled_ReturnsCorrectCriticalChance()
    {
        // Arrange
        var expectedCriticalChance = 0.10;

        // Act
        var actualCriticalChance = _knight.CriticalChance;

        // Assert
        Assert.Equal( expectedCriticalChance, actualCriticalChance );
    }

    [Fact]
    public void SpecialAbility_WhenCalled_ReturnsCorrectSpecialAbility()
    {
        // Arrange
        var expectedSpecialAbility = "Блок щитом (шанс 25% уменьшить урон на 50%)";

        // Act
        var actualSpecialAbility = _knight.SpecialAbility;

        // Assert
        Assert.Equal( expectedSpecialAbility, actualSpecialAbility );
    }
}