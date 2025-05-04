using Fighters.Models.Fighter;

namespace FightersGame.Manager;
public interface IGameManager
{
    public void StartBattle( List<IFighter> fighters );
}
