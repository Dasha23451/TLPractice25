using Fighters;
using Fighters.Creator;
using Fighters.Models.Fighter;

namespace FightersGame;

public class FighterController
{
    private List<IFighter> _fighters = new List<IFighter>();
    private readonly IConsoleFighterCreator _consoleFighterCreator = new ConsoleFighterCreator();
    private readonly GameManager _gameManager = new GameManager();

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
