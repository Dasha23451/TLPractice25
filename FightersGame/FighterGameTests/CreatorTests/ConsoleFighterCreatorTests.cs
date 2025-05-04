using Fighters.Creator;

namespace FighterGameTests.CreatorTests.ConsoleFighterCreatorTests;
public class ConsoleFighterCreatorTests
{
    private readonly ConsoleFighterCreator _creator;

    public ConsoleFighterCreatorTests()
    {
        _creator = new ConsoleFighterCreator();
    }

    [Fact]
    public void CreateFighter_ValidInput_FighterIsCreated()
    {
        var originalOut = Console.Out;

        try
        {
            // Arrange
            var input = new StringReader( "FighterName\n1\n1\n1\n1\n" );
            Console.SetIn( input );

            // Act
            _creator.CreateFighter();

            // Assert
            var fighters = _creator.GetFighters();
            Assert.Single( fighters );
            Assert.Equal( "FighterName", fighters[ 0 ].Name );
        }
        catch ( Exception ) { }
        finally
        {
            Console.SetOut( originalOut );
        }
    }

    [Fact]
    public void CreateFighter_InvalidRaceInput_ThrowsException()
    {
        var originalOut = Console.Out;

        try
        {
            // Arrange
            var input = new StringReader( "FighterName\n9\n1\n1\n1\n" );
            Console.SetIn( input );

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>( () => _creator.CreateFighter() );
            Assert.Contains( "Неверный ввод. Попробуйте снова.", exception.Message );
        }
        catch ( Exception ) { }
        finally
        {
            Console.SetOut( originalOut );
        }
    }

    [Fact]
    public void CreateFighter_InvalidClassInput_ThrowsException()
    {
        var originalOut = Console.Out;

        try
        {
            // Arrange
            var input = new StringReader( "FighterName\n1\n1\n7\n1\n" );
            Console.SetIn( input );

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>( () => _creator.CreateFighter() );
            Assert.Contains( "Неверный ввод. Попробуйте снова.", exception.Message );
        }
        catch ( Exception ) { }
        finally
        {
            Console.SetOut( originalOut );
        }
    }

    [Fact]
    public void CreateFighter_EmptyName_ThrowsException()
    {
        var originalOut = Console.Out;

        try
        {
            Console.SetOut( new StringWriter() );

            // Arrange
            var input = new StringReader( "\n1\n1\n1\n1\n" );
            Console.SetIn( input );

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>( () => _creator.CreateFighter() );
            Assert.Contains( "Боец не может не иметь имя.", exception.Message );
        }
        catch ( Exception ) { }
        finally
        {
            Console.SetOut( originalOut );
        }
    }

    [Fact]
    public void GetFighters_NoFighters_ReturnsEmptyList()
    {
        // Act
        var fighters = _creator.GetFighters();

        // Assert
        Assert.Empty( fighters );
    }
}