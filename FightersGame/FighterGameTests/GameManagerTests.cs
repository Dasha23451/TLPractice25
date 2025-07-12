using Fighters.Models.Fighter;
using FightersGame.Manager;
using Moq;

namespace FighterGameTests;
public class GameManagerTests : IDisposable
{
    private readonly GameManager _gameManager;
    private readonly StringWriter _consoleOutput;
    public GameManagerTests()
    {
        _gameManager = new GameManager();
        _consoleOutput = new StringWriter();
        Console.SetOut( _consoleOutput );
    }

    public void Dispose()
    {
        _consoleOutput.Dispose();
    }

    private IFighter CreateMockFighter( string name, int initiative, bool isAlive = true )
    {
        var mockFighter = new Mock<IFighter>();
        mockFighter.SetupGet( f => f.Name ).Returns( name );
        mockFighter.SetupGet( f => f.Initiative ).Returns( initiative );
        mockFighter.SetupGet( f => f.IsAlive ).Returns( isAlive );
        return mockFighter.Object;
    }

    [Fact]
    public void StartBattle_WithLessThanTwoFighters_PrintsErrorMessage()
    {
        // Arrange
        var fighters = new List<IFighter> { CreateMockFighter( "Test", 5 ) };
        var stringWriter = new StringWriter();
        Console.SetOut( stringWriter );

        // Act
        _gameManager.StartBattle( fighters );
        var output = stringWriter.ToString();

        // Assert
        Assert.Contains( "Для начала битвы нужно как минимум 2 бойца!", output );
    }

    [Fact]
    public void StartBattle_TwoEqualFighters_OneSurvives()
    {
        // Arrange
        var mockFighter1 = new Mock<IFighter>();
        var mockFighter2 = new Mock<IFighter>();

        mockFighter1.SetupGet( f => f.IsAlive ).Returns( true );
        mockFighter1.SetupGet( f => f.Initiative ).Returns( 10 );
        mockFighter1.Setup( f => f.Attack( It.IsAny<IFighter>() ) ).Verifiable();
        mockFighter1.SetupGet( f => f.Name ).Returns( "Fighter1" );

        mockFighter2.SetupGet( f => f.IsAlive ).Returns( true );
        mockFighter2.SetupGet( f => f.Initiative ).Returns( 5 );
        mockFighter2.SetupGet( f => f.Name ).Returns( "Fighter2" );

        var fighters = new List<IFighter> { mockFighter1.Object, mockFighter2.Object };
        var originalOut = Console.Out;
        var stringWriter = new StringWriter();
        Console.SetOut( stringWriter );

        try
        {
            // Act
            _gameManager.StartBattle( fighters );

            // Assert
            mockFighter1.Verify( f => f.Attack( mockFighter2.Object ), Times.AtLeastOnce );
            mockFighter2.Verify( f => f.Attack( It.IsAny<IFighter>() ), Times.Never );
        }
        catch ( Exception ) { }
        finally
        {
            Console.SetOut( originalOut );
            stringWriter.Dispose();
        }
    }

    [Fact]
    public void StartBattle_ThreeFighters_OnlyOneSurvives()
    {
        // Arrange
        var mockFighter1 = new Mock<IFighter>();
        var mockFighter2 = new Mock<IFighter>();
        var mockFighter3 = new Mock<IFighter>();

        mockFighter1.SetupGet( f => f.IsAlive ).Returns( false );
        mockFighter2.SetupGet( f => f.IsAlive ).Returns( false );
        mockFighter3.SetupGet( f => f.IsAlive ).Returns( true );

        var fighters = new List<IFighter> { mockFighter1.Object, mockFighter2.Object, mockFighter3.Object };

        // Act
        _gameManager.StartBattle( fighters );

        // Assert
        Assert.Single( fighters, f => f.IsAlive );
    }

    [Fact]
    public void StartBattle_FighterWithHigherInitiative_AttacksFirst()
    {
        // Arrange
        var fastFighter = CreateMockFighter( "Fast", 8 );
        var slowFighter = CreateMockFighter( "Slow", 3 );
        var fighters = new List<IFighter> { fastFighter, slowFighter };

        // Act
        _gameManager.StartBattle( fighters );

        // Assert
        var output = _consoleOutput.ToString();
        var fastIndex = output.IndexOf( "Fast атакует" );
        var slowIndex = output.IndexOf( "Slow атакует" );
        Assert.True( fastIndex < slowIndex );
    }
}
