using Fighters.Models.Armors;

namespace FighterGameTests.ModelsTests.ArmorsTests;
public class DragonScaleArmorTests
{
    private readonly DragonScaleArmor _dragonScaleArmor;

    public DragonScaleArmorTests()
    {
        _dragonScaleArmor = new DragonScaleArmor();
    }

    [Fact]
    public void Name_ReturnsCorrectName()
    {
        // Act
        var name = _dragonScaleArmor.Name;

        // Assert
        Assert.Equal( "Драконий доспех", name );
    }

    [Fact]
    public void ArmorValue_ReturnsCorrectValue()
    {
        // Act
        var armorValue = _dragonScaleArmor.ArmorValue;

        // Assert
        Assert.Equal( 20, armorValue );
    }

    [Fact]
    public void SpecialEffect_ReturnsCorrectEffect()
    {
        // Act
        var specialEffect = _dragonScaleArmor.SpecialEffect;

        // Assert
        Assert.Equal( "Блокирует 30% урона", specialEffect );
    }

    [Theory]
    [InlineData( 100, 66 )]
    [InlineData( 50, 33 )]
    [InlineData( 0, 0 )]
    public void CalculateDamageReduction_ReturnsCorrectValue( int incomingDamage, int expectedDamage )
    {
        // Act
        var reducedDamage = _dragonScaleArmor.CalculateDamageReduction( incomingDamage );

        // Assert
        Assert.Equal( expectedDamage, reducedDamage );
    }
}