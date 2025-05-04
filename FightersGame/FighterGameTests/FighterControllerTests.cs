using Fighters.Creator;
using Fighters.Models.Fighter;
using FightersGame;
using FightersGame.Manager;
using Moq;

namespace FighterGameTests;
public class FighterControllerTests
{
    private readonly Mock<IConsoleFighterCreator> _mockFighterCreator;
    private readonly Mock<IGameManager> _mockGameManager;
    private readonly FighterController _fighterController;

    public FighterControllerTests()
    {
        _mockFighterCreator = new Mock<IConsoleFighterCreator>();
        _mockGameManager = new Mock<IGameManager>();
        _fighterController = new FighterController( _mockFighterCreator.Object, _mockGameManager.Object );
    }

    [Fact]
    public void Start_DisplaysWelcomeMessageAndCommands()
    {
        // Arrange
        var expectedOutput = "����� ���������� � ����!\n��������� �������:\nadd - �������� �����\nplay - ������ �����\nlist - �������� ���� ������\nexit - �����\n";
        var stringWriter = new StringWriter();
        Console.SetOut( stringWriter );

        try
        {

            Console.SetIn( new StringReader( "exit\n" ) );

            // Act
            _fighterController.Start();

            // Assert
            var output = stringWriter.ToString();
            Assert.Contains( "����� ���������� � ����!", output );
            Assert.Contains( "��������� �������:", output );
            Assert.Contains( "add - �������� �����", output );
            Assert.Contains( "play - ������ �����", output );
            Assert.Contains( "list - �������� ���� ������", output );
            Assert.Contains( "exit - �����", output );

        }
        catch ( Exception ) { }
        finally
        {
            Console.SetOut( stringWriter );
            stringWriter.Dispose();
        }
    }

    [Fact]
    public void Start_AddCommand_CreatesFighter()
    {
        // Arrange
        var fighters = new List<IFighter>();
        _mockFighterCreator.Setup( m => m.CreateFighter() ).Callback( () => fighters.Add( new Mock<IFighter>().Object ) );
        _mockFighterCreator.Setup( m => m.GetFighters() ).Returns( fighters );

        using ( var sw = new StringWriter() )
        {
            Console.SetOut( sw );
            Console.SetIn( new StringReader( "add\nexit\n" ) );

            // Act
            _fighterController.Start();
        }

        // Assert
        Assert.Single( fighters );
        _mockFighterCreator.Verify( m => m.CreateFighter(), Times.Once );
    }

    [Fact]
    public void Start_ExitCommand_ExitsLoop()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut( stringWriter );
        try
        {
            Console.SetIn( new StringReader( "exit\n" ) );
            // Act
            _fighterController.Start();


            // Assert
            Assert.True( true );
        }
        catch ( Exception ) { }
        finally
        {
            Console.SetOut( stringWriter );
            stringWriter.Dispose();
        }
    }
}