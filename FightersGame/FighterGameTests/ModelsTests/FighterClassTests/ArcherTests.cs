using Fighters.Models.FighterClass;

namespace FighterGameTests.ModelsTests.FighterClassTests;
public class ArcherTests
{
    private readonly Archer _archer;

    public ArcherTests()
    {
        _archer = new Archer();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Лучник";

        // Act
        var actualName = _archer.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void HealthBonus_WhenCalled_ReturnsCorrectHealthBonus()
    {
        // Arrange
        var expectedHealthBonus = 20;

        // Act
        var actualHealthBonus = _archer.HealthBonus;

        // Assert
        Assert.Equal( expectedHealthBonus, actualHealthBonus );
    }

    [Fact]
    public void DamageBonus_WhenCalled_ReturnsCorrectDamageBonus()
    {
        // Arrange
        var expectedDamageBonus = 8;

        // Act
        var actualDamageBonus = _archer.DamageBonus;

        // Assert
        Assert.Equal( expectedDamageBonus, actualDamageBonus );
    }

    [Fact]
    public void ArmorBonus_WhenCalled_ReturnsCorrectArmorBonus()
    {
        // Arrange
        var expectedArmorBonus = 1;

        // Act
        var actualArmorBonus = _archer.ArmorBonus;

        // Assert
        Assert.Equal( expectedArmorBonus, actualArmorBonus );
    }

    [Fact]
    public void InitiativeBonus_WhenCalled_ReturnsCorrectInitiativeBonus()
    {
        // Arrange
        var expectedInitiativeBonus = 6;

        // Act
        var actualInitiativeBonus = _archer.InitiativeBonus;

        // Assert
        Assert.Equal( expectedInitiativeBonus, actualInitiativeBonus );
    }

    [Fact]
    public void CriticalChance_WhenCalled_ReturnsCorrectCriticalChance()
    {
        // Arrange
        var expectedCriticalChance = 0.15;

        // Act
        var actualCriticalChance = _archer.CriticalChance;

        // Assert
        Assert.Equal( expectedCriticalChance, actualCriticalChance );
    }

    [Fact]
    public void SpecialAbility_WhenCalled_ReturnsCorrectSpecialAbility()
    {
        // Arrange
        var expectedSpecialAbility = "Меткий выстрел (шанс 15% на двойной урон)";

        // Act
        var actualSpecialAbility = _archer.SpecialAbility;

        // Assert
        Assert.Equal( expectedSpecialAbility, actualSpecialAbility );
    }
}
