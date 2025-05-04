using Fighters;
using Fighters.Creator;
using Fighters.Models.Fighter;
using FightersGame.Manager;

namespace FightersGame;

public class FighterController
{
    private List<IFighter> _fighters = new List<IFighter>();
    private readonly IConsoleFighterCreator _consoleFighterCreator = new ConsoleFighterCreator();
    private readonly IGameManager _gameManager = new GameManager();

    public FighterController() { }
    public FighterController( IConsoleFighterCreator fighterCreator, IGameManager gameManager )
    {
        _consoleFighterCreator = fighterCreator;
        _gameManager = gameManager;
    }

    public void Start()
    {
        Console.WriteLine( "Добро пожаловать в игру!" );
        Console.WriteLine( "Доступные команды:" );
        Console.WriteLine( "add - добавить бойца" );
        Console.WriteLine( "play - начать битву" );
        Console.WriteLine( "list - показать всех бойцов" );
        Console.WriteLine( "exit - выход" );

        while ( true )
        {
            Console.Write( "\nВведите команду: " );
            var command = Console.ReadLine()?.ToLower().Trim();

            switch ( command )
            {
                case "add":
                    _consoleFighterCreator.CreateFighter();
                    _fighters = _consoleFighterCreator.GetFighters();
                    break;

                case "play":
                    _gameManager.StartBattle( _fighters );
                    break;

                case "list":
                    DisplayAllFighters();
                    break;

                case "exit":
                    return;

                default:
                    Console.WriteLine( "Неизвестная команда" );
                    break;
            }
        }
    }
    private void DisplayAllFighters()
    {
        Console.WriteLine( "\n=== ВСЕ БОЙЦЫ ===" );
        foreach ( var fighter in _fighters )
        {
            fighter.DisplayStats();
        }
    }
}
