using Domain.Entities;

namespace Domain.Interfaces;
public interface IPropertyRepository
{
    public Property? GetById( Guid id );
    public void Create( Property property );
    public List<Property> GetAll();
    public void Update( Property property );
    public void Delete( Guid id );
}
