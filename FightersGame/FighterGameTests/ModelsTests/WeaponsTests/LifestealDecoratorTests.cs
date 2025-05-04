using Fighters.Models.Weapons;
using Moq;

namespace FighterGameTests.ModelsTests.WeaponsTests;
public class LifestealDecoratorTests
{
    private readonly Mock<IWeapon> _mockWeapon;
    private readonly LifestealDecorator _lifestealDecorator;

    public LifestealDecoratorTests()
    {
        _mockWeapon = new Mock<IWeapon>();
        _mockWeapon.Setup( w => w.Name ).Returns( "Меч" );
        _mockWeapon.Setup( w => w.Damage ).Returns( 10 );
        _mockWeapon.Setup( w => w.CritChance ).Returns( 15 );
        _mockWeapon.Setup( w => w.SpecialEffect ).Returns( "" );
        _mockWeapon.Setup( w => w.Rarity ).Returns( Rarity.Rare );

        _lifestealDecorator = new LifestealDecorator( _mockWeapon.Object, 20 );
    }

    [Fact]
    public void Name_WhenCalled_ReturnsCorrectName()
    {
        // Act
        var actualName = _lifestealDecorator.Name;

        // Assert
        Assert.Equal( "Меч", actualName );
    }

    [Fact]
    public void Damage_WhenCalled_ReturnsCorrectDamage()
    {
        // Act
        var actualDamage = _lifestealDecorator.Damage;

        // Assert
        Assert.Equal( 10, actualDamage );
    }

    [Fact]
    public void CritChance_WhenCalled_ReturnsCorrectCritChance()
    {
        // Act
        var actualCritChance = _lifestealDecorator.CritChance;

        // Assert
        Assert.Equal( 15, actualCritChance );
    }

    [Fact]
    public void SpecialEffect_WhenCalled_ReturnsCorrectSpecialEffect()
    {
        // Arrange
        var expectedSpecialEffect = ", Кража здоровья 20%";

        // Act
        var actualSpecialEffect = _lifestealDecorator.SpecialEffect;

        // Assert
        Assert.Equal( expectedSpecialEffect, actualSpecialEffect );
    }

    [Fact]
    public void Rarity_WhenCalled_ReturnsCorrectRarity()
    {
        // Act
        var actualRarity = _lifestealDecorator.Rarity;

        // Assert
        Assert.Equal( Rarity.Rare, actualRarity );
    }
}