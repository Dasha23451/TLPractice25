using Fighters.Models.Armors;
using Moq;

namespace FighterGameTests.ModelsTests.ArmorsTests;
public class NoArmorTests
{
    private readonly NoArmor _noArmor;

    public NoArmorTests()
    {
        _noArmor = new NoArmor();
    }

    [Fact]
    public void Name_ReturnsCorrectName()
    {
        // Act
        var name = _noArmor.Name;

        // Assert
        Assert.Equal( "Без брони", name );
    }

    [Fact]
    public void ArmorValue_ReturnsCorrectValue()
    {
        // Act
        var armorValue = _noArmor.ArmorValue;

        // Assert
        Assert.Equal( 0, armorValue );
    }

    [Fact]
    public void SpecialEffect_ReturnsCorrectEffect()
    {
        // Act
        var specialEffect = _noArmor.SpecialEffect;

        // Assert
        Assert.Equal( "+15% к уклонению", specialEffect );
    }

    [Theory]
    [InlineData( 100, 100 )]
    [InlineData( 50, 50 )]
    [InlineData( 0, 0 )]
    public void CalculateDamageReduction_ReturnsExpectedValue( int incomingDamage, int expectedDamage )
    {
        // Arrange
        var randomMock = new Mock<Random>();
        randomMock.Setup( r => r.Next( 100 ) ).Returns( 99 );
        var armor = new NoArmor( randomMock.Object );

        // Act
        var reducedDamage = armor.CalculateDamageReduction( incomingDamage );

        // Assert
        Assert.Equal( expectedDamage, reducedDamage );
    }

    [Fact]
    public void CalculateDamageReduction_ReturnsZero_WhenEvasionOccurs()
    {
        // Arrange
        var random = new Mock<Random>();
        random.Setup( r => r.Next( 100 ) ).Returns( 5 );
        var armor = new NoArmor( random.Object );

        // Act
        var reducedDamage = armor.CalculateDamageReduction( 100 );

        // Assert
        Assert.Equal( 0, reducedDamage );
    }
}