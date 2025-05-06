using Domain.Entities;

namespace Domain.Interfaces;
public interface IPropertyService
{
    public List<Property> GetAllProperties();
    public Property? GetPropertyById( Guid id );
    public Property CreateProperty( Property property );
    public void UpdateProperty( Property property );
    public void DeleteProperty( Guid id );
}
