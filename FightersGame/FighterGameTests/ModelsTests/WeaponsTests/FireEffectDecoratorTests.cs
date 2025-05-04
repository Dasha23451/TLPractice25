using Fighters.Models.Weapons;
using Moq;

namespace FighterGameTests.ModelsTests.WeaponsTests;
public class FireEffectDecoratorTests
{
    private readonly Mock<IWeapon> _mockWeapon;
    private readonly FireEffectDecorator _fireEffectDecorator;

    public FireEffectDecoratorTests()
    {
        _mockWeapon = new Mock<IWeapon>();
        _mockWeapon.Setup( w => w.Name ).Returns( "Лук" );
        _mockWeapon.Setup( w => w.Damage ).Returns( 8 );
        _mockWeapon.Setup( w => w.CritChance ).Returns( 10 );
        _mockWeapon.Setup( w => w.SpecialEffect ).Returns( "" );
        _mockWeapon.Setup( w => w.Rarity ).Returns( Rarity.Common );

        _fireEffectDecorator = new FireEffectDecorator( _mockWeapon.Object );
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Act
        var actualName = _fireEffectDecorator.Name;

        // Assert
        Assert.Equal( "Лук", actualName );
    }

    [Fact]
    public void Damage_WhenCalled_ReturnsIncreasedDamage()
    {
        // Arrange
        var expectedDamage = 13;

        // Act
        var actualDamage = _fireEffectDecorator.Damage;

        // Assert
        Assert.Equal( expectedDamage, actualDamage );
    }

    [Fact]
    public void CritChance_WhenCalled_ReturnsCorrectCritChance()
    {
        // Act
        var actualCritChance = _fireEffectDecorator.CritChance;

        // Assert
        Assert.Equal( 10, actualCritChance );
    }

    [Fact]
    public void SpecialEffect_WhenCalled_ReturnsEmptySpecialEffect()
    {
        // Act
        var actualSpecialEffect = _fireEffectDecorator.SpecialEffect;

        // Assert
        Assert.Equal( "", actualSpecialEffect );
    }

    [Fact]
    public void Rarity_WhenCalled_ReturnsCorrectRarity()
    {
        // Act
        var actualRarity = _fireEffectDecorator.Rarity;

        // Assert
        Assert.Equal( Rarity.Common, actualRarity );
    }
}