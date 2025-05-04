using Fighters.Models.Fighter;

namespace Fighters.Creator;
public interface IConsoleFighterCreator
{
    public void CreateFighter();
    public List<IFighter> GetFighters();
}