using Fighters.Models.Armors;

namespace FighterGameTests.ModelsTests.ArmorsTests;
public class CursedArmorTests
{
    private readonly CursedArmor _cursedArmor;

    public CursedArmorTests()
    {
        _cursedArmor = new CursedArmor();
    }

    [Fact]
    public void Name_ReturnsCorrectName()
    {
        // Act
        var name = _cursedArmor.Name;

        // Assert
        Assert.Equal( "Проклятая броня", name );
    }

    [Fact]
    public void ArmorValue_ReturnsCorrectValue()
    {
        // Act
        var armorValue = _cursedArmor.ArmorValue;

        // Assert
        Assert.Equal( 25, armorValue );
    }

    [Fact]
    public void SpecialEffect_ReturnsCorrectEffect()
    {
        // Act
        var specialEffect = _cursedArmor.SpecialEffect;

        // Assert
        Assert.Equal( "Постепенно уменьшает здоровье владельца", specialEffect );
    }

    [Theory]
    [InlineData( 100, 35 )]
    [InlineData( 50, 22 )]
    [InlineData( 0, 10 )]
    public void CalculateDamageReduction_ReturnsCorrectValue( int incomingDamage, int expectedDamage )
    {
        // Act
        var reducedDamage = _cursedArmor.CalculateDamageReduction( incomingDamage );

        // Assert
        Assert.Equal( expectedDamage, reducedDamage );
    }
}
