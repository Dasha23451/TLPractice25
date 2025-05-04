using Fighters.Models.Fighter;

namespace FightersGame.Manager;
public class GameManager : IGameManager
{
    public void StartBattle( List<IFighter> fighters )
    {
        if ( fighters.Count < 2 )
        {
            Console.WriteLine( "Для начала битвы нужно как минимум 2 бойца!" );
            return;
        }

        Console.WriteLine( "\n=== НАЧАЛО БИТВЫ ===" );

        int round = 1;
        var aliveFighters = fighters.Where( f => f.IsAlive ).OrderByDescending( f => f.Initiative ).ToList();

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

            aliveFighters = fighters.Where( f => f.IsAlive ).ToList();
            round++;
        }

        var winner = fighters.FirstOrDefault( f => f.IsAlive );
        if ( winner != null )
        {
            Console.WriteLine( $"\n{winner.Name} побеждает в битве!" );
        }
        else
        {
            Console.WriteLine( "\nВсе бойцы погибли..." );
        }
    }
}
