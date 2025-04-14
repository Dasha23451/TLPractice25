using Fighters.Models.Fighter;

namespace Fighters.Controller;
public interface IFighterController
{
    public void CreateFighter();
    public List<IFighter> GetFighters();
}