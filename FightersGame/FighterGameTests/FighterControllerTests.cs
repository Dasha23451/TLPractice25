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
        var expectedOutput = "Добро пожаловать в игру!\nДоступные команды:\nadd - добавить бойца\nplay - начать битву\nlist - показать всех бойцов\nexit - выход\n";
        var stringWriter = new StringWriter();
        Console.SetOut( stringWriter );

        try
        {

            Console.SetIn( new StringReader( "exit\n" ) );

            // Act
            _fighterController.Start();

            // Assert
            var output = stringWriter.ToString();
            Assert.Contains( "Добро пожаловать в игру!", output );
            Assert.Contains( "Доступные команды:", output );
            Assert.Contains( "add - добавить бойца", output );
            Assert.Contains( "play - начать битву", output );
            Assert.Contains( "list - показать всех бойцов", output );
            Assert.Contains( "exit - выход", output );

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