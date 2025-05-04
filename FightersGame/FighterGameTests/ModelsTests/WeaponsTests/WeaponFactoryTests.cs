using Fighters.Models.Weapons;

namespace FighterGameTests.ModelsTests.WeaponsTests;
public class WeaponFactoryTests
{
    [Fact]
    public void CreateWeapon_ValidTypeAxe_ReturnsAxeInstance()
    {
        // Act
        var weapon = WeaponFactory.CreateWeapon( "топор" );

        // Assert
        Assert.IsType<Axe>( weapon );
    }

    [Fact]
    public void CreateWeapon_ValidTypeBow_ReturnsBowInstance()
    {
        // Act
        var weapon = WeaponFactory.CreateWeapon( "лук" );

        // Assert
        Assert.IsType<Bow>( weapon );
    }

    [Fact]
    public void CreateWeapon_ValidTypeFirsts_ReturnsFirstsInstance()
    {
        // Act
        var weapon = WeaponFactory.CreateWeapon( "кулаки" );

        // Assert
        Assert.IsType<Firsts>( weapon );
    }

    [Fact]
    public void CreateWeapon_ValidTypeStaff_ReturnsStaffInstance()
    {
        // Act
        var weapon = WeaponFactory.CreateWeapon( "посох" );

        // Assert
        Assert.IsType<Staff>( weapon );
    }

    [Fact]
    public void CreateWeapon_ValidTypeSword_ReturnsSwordInstance()
    {
        // Act
        var weapon = WeaponFactory.CreateWeapon( "меч" );

        // Assert
        Assert.IsType<Sword>( weapon );
    }

    [Fact]
    public void CreateWeapon_InvalidType_ThrowsArgumentException()
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>( () => WeaponFactory.CreateWeapon( "неизвестный тип" ) );
        Assert.Equal( "Неверный ввод. Попробуйте снова", exception.Message );
    }
}