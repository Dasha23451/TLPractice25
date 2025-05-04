using Fighters.Models.Armors;

namespace FighterGameTests.ModelsTests.ArmorsTests;
public class MageRobeTests
{
    private readonly MageRobe _mageRobe;

    public MageRobeTests()
    {
        _mageRobe = new MageRobe();
    }

    [Fact]
    public void Name_ReturnsCorrectName()
    {
        // Act
        var name = _mageRobe.Name;

        // Assert
        Assert.Equal( "Мантия мага", name );
    }

    [Fact]
    public void ArmorValue_ReturnsCorrectValue()
    {
        // Act
        var armorValue = _mageRobe.ArmorValue;

        // Assert
        Assert.Equal( 5, armorValue );
    }

    [Fact]
    public void SpecialEffect_ReturnsCorrectEffect()
    {
        // Act
        var specialEffect = _mageRobe.SpecialEffect;

        // Assert
        Assert.Equal( "+20% маг.защита", specialEffect );
    }

    [Theory]
    [InlineData( 100, 75 )]
    [InlineData( 50, 37 )]
    [InlineData( 0, 0 )]
    public void CalculateDamageReduction_ReturnsCorrectValue( int incomingDamage, int expectedDamage )
    {
        // Act
        var reducedDamage = _mageRobe.CalculateDamageReduction( incomingDamage );

        // Assert
        Assert.Equal( expectedDamage, reducedDamage );
    }
}