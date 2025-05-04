using Fighters.Models.Armors;

namespace FighterGameTests.ModelsTests.ArmorsTests;
public class PlateTests
{
    private readonly Plate _plate;

    public PlateTests()
    {
        _plate = new Plate();
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Arrange
        var expectedName = "Латы";

        // Act
        var actualName = _plate.Name;

        // Assert
        Assert.Equal( expectedName, actualName );
    }

    [Fact]
    public void ArmorValue_WhenCalled_ReturnsCorrectArmorValue()
    {
        // Arrange
        var expectedArmorValue = 22;

        // Act
        var actualArmorValue = _plate.ArmorValue;

        // Assert
        Assert.Equal( expectedArmorValue, actualArmorValue );
    }

    [Fact]
    public void SpecialEffect_WhenCalled_ReturnsCorrectSpecialEffect()
    {
        // Arrange
        var expectedSpecialEffect = "Блокирует 10% урона";

        // Act
        var actualSpecialEffect = _plate.SpecialEffect;

        // Assert
        Assert.Equal( expectedSpecialEffect, actualSpecialEffect );
    }

    [Theory]
    [InlineData( 100, 1 )]
    [InlineData( 50, 0 )]
    [InlineData( 0, 0 )]
    public void CalculateDamageReduction_ValidDamage_ReturnsCorrectReduction( int incomingDamage, int expectedReduction )
    {
        // Act
        var actualReduction = _plate.CalculateDamageReduction( incomingDamage );

        // Assert
        Assert.Equal( expectedReduction, actualReduction );
    }
}