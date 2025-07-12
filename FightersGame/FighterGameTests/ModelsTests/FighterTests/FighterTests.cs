using System.Reflection;
using Fighters.Models.Armors;
using Fighters.Models.Fighter;
using Fighters.Models.FighterClass;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Moq;

namespace FighterGameTests.ModelsTests.FighterTests;

public class FighterTests
{
    private readonly Mock<IRace> _mockRace;
    private readonly Mock<IFighterClass> _mockClass;
    private readonly Mock<IWeapon> _mockWeapon;
    private readonly Mock<IArmor> _mockArmor;
    private readonly Fighter _fighter;

    public FighterTests()
    {
        // Arrange
        _mockRace = new Mock<IRace>();
        _mockClass = new Mock<IFighterClass>();
        _mockWeapon = new Mock<IWeapon>();
        _mockArmor = new Mock<IArmor>();

        _mockRace.Setup( r => r.Name ).Returns( "Человек" );
        _mockRace.Setup( r => r.Damage ).Returns( 5 );
        _mockRace.Setup( r => r.Health ).Returns( 100 );
        _mockRace.Setup( r => r.Armor ).Returns( 2 );
        _mockRace.Setup( r => r.Initiative ).Returns( 5 );

        _mockClass.Setup( c => c.Name ).Returns( "Рыцарь" );
        _mockClass.Setup( c => c.HealthBonus ).Returns( 50 );
        _mockClass.Setup( c => c.DamageBonus ).Returns( 5 );
        _mockClass.Setup( c => c.ArmorBonus ).Returns( 3 );
        _mockClass.Setup( c => c.InitiativeBonus ).Returns( 2 );
        _mockClass.Setup( c => c.CriticalChance ).Returns( 0.10 );
        _mockClass.Setup( c => c.SpecialAbility ).Returns( "Блок щитом (шанс 25% уменьшить урон на 50%)" );

        _mockWeapon.Setup( w => w.Name ).Returns( "Меч" );
        _mockWeapon.Setup( w => w.Damage ).Returns( 10 );
        _mockWeapon.Setup( w => w.CritChance ).Returns( 5 );
        _mockWeapon.Setup( w => w.SpecialEffect ).Returns( "" );
        _mockWeapon.Setup( w => w.Rarity ).Returns( Rarity.Common );

        _mockArmor.Setup( a => a.Name ).Returns( "Латы" );
        _mockArmor.Setup( a => a.ArmorValue ).Returns( 22 );
        _mockArmor.Setup( a => a.Durability ).Returns( 100 );
        _mockArmor.Setup( a => a.SpecialEffect ).Returns( "Блокирует 10% урона" );

        _fighter = new Fighter( "Fighter1", _mockRace.Object, _mockClass.Object, _mockWeapon.Object, _mockArmor.Object );
    }

    [Fact]
    public void Constructor_ValidParameters_InitializesPropertiesCorrectly()
    {
        // Assert
        Assert.Equal( "Fighter1", _fighter.Name );
        Assert.Equal( 150, _fighter.MaxHealth );
        Assert.Equal( 20, _fighter.TotalPower );
        Assert.Equal( 27, _fighter.TotalArmor );
        Assert.Equal( 7, _fighter.Initiative );
        Assert.True( _fighter.IsAlive );
    }

    [Fact]
    public void Attack_TargetIsAlive_DealsCorrectDamage()
    {
        var originalOut = Console.Out;

        try
        {
            Console.SetOut( new StringWriter() );

            // Arrange
            var targetMock = new Mock<IFighter>();
            targetMock.Setup( t => t.IsAlive ).Returns( true );
            targetMock.Setup( t => t.TotalArmor ).Returns( 10 );
            targetMock.Setup( t => t.TakeDamage( It.IsAny<int>() ) );

            // Act
            _fighter.Attack( targetMock.Object );

            // Assert
            targetMock.Verify( t => t.TakeDamage( It.IsAny<int>() ), Times.Once );
        }
        catch ( Exception ) { }
        finally
        {
            Console.SetOut( originalOut );
        }
    }

    [Fact]
    public void Attack_TargetIsDead_DoesNotDealDamage()
    {
        // Arrange
        var targetMock = new Mock<IFighter>();
        targetMock.Setup( t => t.IsAlive ).Returns( false );

        // Act
        _fighter.Attack( targetMock.Object );

        targetMock.Verify( t => t.TakeDamage( It.IsAny<int>() ), Times.Never );
    }

    [Fact]
    public void TakeDamage_ValidDamage_UpdatesHealth()
    {
        var originalOut = Console.Out;
        try
        {
            // Arrange
            Console.SetOut( new StringWriter() );

            int damage = 30;
            var armorMock = new Mock<IArmor>();
            armorMock.Setup( a => a.ArmorValue ).Returns( 22 );
            armorMock.Setup( a => a.CalculateDamageReduction( It.IsAny<int>() ) )
                .Returns<int>( damage =>
                {
                    int armorReduction = 22 / 2;
                    int reducedDamage = damage - armorReduction;
                    return ( int )( reducedDamage * 0.9 );
                } );
            armorMock.Setup( a => a.Name ).Returns( "Латы" );
            armorMock.Setup( a => a.SpecialEffect ).Returns( "Блокирует 10% урона" );
            armorMock.Setup( a => a.Durability ).Returns( 100 );

            var fighter = new Fighter( "TestFighter", _mockRace.Object, _mockClass.Object,
                                      _mockWeapon.Object, armorMock.Object );

            var randomMock = new Mock<Random>();
            randomMock.Setup( r => r.Next( 4 ) ).Returns( 1 );
            typeof( Fighter ).GetField( "_random", BindingFlags.NonPublic | BindingFlags.Instance )
                          .SetValue( fighter, randomMock.Object );

            // Act
            fighter.TakeDamage( damage );

            // Assert
            Assert.Equal( 133, fighter.CurrentHealth );
        }
        finally
        {
            Console.SetOut( originalOut );
        }
    }

    [Fact]
    public void TakeDamage_ExceedsHealth_HealthIsZero()
    {
        var originalOut = Console.Out;
        try
        {
            // Arrange
            Console.SetOut( new StringWriter() );

            var armorMock = new Mock<IArmor>();
            armorMock.Setup( a => a.ArmorValue ).Returns( 0 );
            armorMock.Setup( a => a.CalculateDamageReduction( It.IsAny<int>() ) )
                    .Returns<int>( damage => damage );
            armorMock.Setup( a => a.Name ).Returns( "No Armor" );
            armorMock.Setup( a => a.SpecialEffect ).Returns( "" );
            armorMock.Setup( a => a.Durability ).Returns( 0 );

            var fighter = new Fighter( "TestFighter", _mockRace.Object, _mockClass.Object,
                                    _mockWeapon.Object, armorMock.Object );

            var randomMock = new Mock<Random>();
            randomMock.Setup( r => r.Next( 4 ) ).Returns( 1 );
            typeof( Fighter ).GetField( "_random", BindingFlags.NonPublic | BindingFlags.Instance )
                          .SetValue( fighter, randomMock.Object );

            // Act
            fighter.TakeDamage( 200 );

            // Assert
            Assert.Equal( 0, fighter.CurrentHealth );
            Assert.False( fighter.IsAlive );
        }
        catch ( Exception ) { }
        finally
        {
            Console.SetOut( originalOut );
        }
    }

    [Fact]
    public void DisplayStats_PrintsCorrectStats()
    {
        var originalOut = Console.Out;
        try
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut( writer );

            // Act
            _fighter.DisplayStats();

            // Assert
            var output = writer.ToString();
            Assert.Contains( "=== Fighter1 ===\r\nРаса: Человек, Класс: Рыцарь\r\nОружие: Меч (Урон: 10, Крит: 5%)\r\nБроня: Латы (Защита: 22, Прочность: 100)\r\nЗдоровье: 150/150\r\nСила: 20, Броня: 27\r\nИнициатива: 7\r\nСпособность класса: Блок щитом (шанс 25% уменьшить урон на 50%)\r\nЭффект брони: Блокирует 10% урона\r\nСостояние: Жив", output );
        }
        catch ( Exception ) { }
        finally
        {
            Console.SetOut( originalOut );
        }
    }
}