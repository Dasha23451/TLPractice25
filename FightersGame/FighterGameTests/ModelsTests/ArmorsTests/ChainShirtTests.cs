using Fighters.Models.Armors;

namespace FighterGameTests.ModelsTests.ArmorsTests;
public class ChainShirtTests
{
    private readonly ChainShirt _chainShirt;

    public ChainShirtTests()
    {
        _chainShirt = new ChainShirt();
    }

    [Fact]
    public void Name_ReturnsCorrectName()
    {
        // Act
        var name = _chainShirt.Name;

        // Assert
        Assert.Equal( "Кольчужная рубаха", name );
    }

    [Fact]
    public void ArmorValue_ReturnsCorrectValue()
    {
        // Act
        var armorValue = _chainShirt.ArmorValue;

        // Assert
        Assert.Equal( 12, armorValue );
    }

    [Fact]
    public void Durability_ReturnsDefaultValue()
    {
        // Act
        var durability = _chainShirt.Durability;

        // Assert
        Assert.Equal( 100, durability );
    }

    [Fact]
    public void SpecialEffect_ReturnsDefaultEffect()
    {
        // Act
        var specialEffect = _chainShirt.SpecialEffect;

        // Assert
        Assert.Equal( "Нет", specialEffect );
    }

    [Theory]
    [InlineData( 100, 40 )]
    [InlineData( 50, 20 )]
    [InlineData( 0, 0 )]
    public void CalculateDamageReduction_ReturnsCorrectValue( int incomingDamage, int expectedDamage )
    {
        // Act
        var reducedDamage = _chainShirt.CalculateDamageReduction( incomingDamage );

        // Assert
        Assert.Equal( expectedDamage, reducedDamage );
    }
}
