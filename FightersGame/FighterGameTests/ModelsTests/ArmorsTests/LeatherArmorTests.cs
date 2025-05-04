using Fighters.Models.Armors;
using Moq;

namespace FighterGameTests.ModelsTests.ArmorsTests;
public class LeatherArmorTests
{
    private readonly LeatherArmor _leatherArmor;

    public LeatherArmorTests()
    {
        _leatherArmor = new LeatherArmor();
    }

    [Fact]
    public void Name_ReturnsCorrectName()
    {
        // Act
        var name = _leatherArmor.Name;

        // Assert
        Assert.Equal( "Кожаная броня", name );
    }

    [Fact]
    public void ArmorValue_ReturnsCorrectValue()
    {
        // Act
        var armorValue = _leatherArmor.ArmorValue;

        // Assert
        Assert.Equal( 8, armorValue );
    }

    [Fact]
    public void SpecialEffect_ReturnsCorrectEffect()
    {
        // Act
        var specialEffect = _leatherArmor.SpecialEffect;

        // Assert
        Assert.Equal( "+10% к уклонению", specialEffect );
    }

    [Theory]
    [InlineData( 100, 100 )]
    [InlineData( 50, 50 )]
    [InlineData( 0, 0 )]
    public void CalculateDamageReduction_ReturnsExpectedValue( int incomingDamage, int expectedDamage )
    {
        // Arrange
        var random = new Mock<Random>();
        random.Setup( r => r.Next( 100 ) ).Returns( 99 );
        var armor = new LeatherArmor( random.Object );

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
        var armor = new LeatherArmor( random.Object );

        // Act
        var reducedDamage = armor.CalculateDamageReduction( 100 );

        // Assert
        Assert.Equal( 0, reducedDamage );
    }
}
