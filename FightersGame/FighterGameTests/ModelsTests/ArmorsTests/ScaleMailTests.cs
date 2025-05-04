using Fighters.Models.Armors;

namespace FighterGameTests.ModelsTests.ArmorsTests;
public class ScaleMailTests
{
    private readonly ScaleMail _scaleMail;

    public ScaleMailTests()
    {
        _scaleMail = new ScaleMail();
    }

    [Fact]
    public void Name_ReturnsCorrectName()
    {
        // Act
        var name = _scaleMail.Name;

        // Assert
        Assert.Equal( "Чешуйчатый доспех", name );
    }

    [Fact]
    public void ArmorValue_ReturnsCorrectValue()
    {
        // Act
        var armorValue = _scaleMail.ArmorValue;

        // Assert
        Assert.Equal( 15, armorValue );
    }

    [Fact]
    public void SpecialEffect_ReturnsCorrectEffect()
    {
        // Act
        var specialEffect = _scaleMail.SpecialEffect;

        // Assert
        Assert.Equal( "-20% крит урон", specialEffect );
    }

    [Theory]
    [InlineData( 100, 20 )]
    [InlineData( 50, 9 )]
    [InlineData( 0, 0 )]
    public void CalculateDamageReduction_ReturnsCorrectValue( int incomingDamage, int expectedDamage )
    {
        // Act
        var reducedDamage = _scaleMail.CalculateDamageReduction( incomingDamage );

        // Assert
        Assert.Equal( expectedDamage, reducedDamage );
    }
}