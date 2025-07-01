using Domain.Interfaces;
using Domain.Entities;

namespace Infrastructure.Service;
public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _propertyRepository;

    public PropertyService( IPropertyRepository propertyRepository )
    {
        _propertyRepository = propertyRepository;
    }

    public Property? GetPropertyById( Guid id )
    {
        return _propertyRepository.GetById( id );
    }

    public List<Property> GetAllProperties()
    {
        return _propertyRepository.GetAll();
    }

    public Property CreateProperty( Property property )
    {
        _propertyRepository.Create( property );
        return property;
    }

    public void UpdateProperty( Property property )
    {
        _propertyRepository.Update( property );
    }

    public void DeleteProperty( Guid id )
    {
        _propertyRepository.Delete( id );
    }
}