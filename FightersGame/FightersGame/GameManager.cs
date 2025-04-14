namespace Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using Fighters.Models.Fighter;
using Fighters.Controller;
public class GameManager
{
    private List<IFighter> _fighters = new List<IFighter>();
    private readonly IFighterController _fighterController = new FighterController();

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
                    _fighterController.CreateFighter();
                    _fighters = _fighterController.GetFighters();
                    break;

                case "play":
                    StartBattle();
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
    private void StartBattle()
    {
        if ( _fighters.Count < 2 )
        {
            Console.WriteLine( "Для начала битвы нужно как минимум 2 бойца!" );
            return;
        }

        Console.WriteLine( "\n=== НАЧАЛО БИТВЫ ===" );

        int round = 1;
        var aliveFighters = _fighters.Where( f => f.IsAlive ).OrderByDescending( f => f.Initiative ).ToList();

        while ( aliveFighters.Count > 1 )
        {
            Console.WriteLine( $"\n=== РАУНД {round} ===" );

            foreach ( var attacker in aliveFighters.Where( f => f.IsAlive ) )
            {
                if ( !attacker.IsAlive )
                    continue;

                var targets = aliveFighters.Where( f => f.IsAlive && f != attacker ).ToList();
                if ( targets.Count == 0 )
                    break;

                var target = targets[ new Random().Next( targets.Count ) ];
                attacker.Attack( target );
            }

            aliveFighters = _fighters.Where( f => f.IsAlive ).ToList();
            round++;
        }

        var winner = _fighters.FirstOrDefault( f => f.IsAlive );
        if ( winner != null )
        {
            Console.WriteLine( $"\n{winner.Name} побеждает в битве!" );
        }
        else
        {
            Console.WriteLine( "\nВсе бойцы погибли..." );
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
