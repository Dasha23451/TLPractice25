using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class PropertyRepository : IPropertyRepository
{
    private readonly List<Property> _properties = new List<Property>();

    public Property? GetById( Guid id )
    {
        return _properties.FirstOrDefault( p => p.Id == id );
    }

    public List<Property> GetAll()
    {
        return _properties.ToList();
    }

    public void Create( Property property )
    {
        _properties.Add( property );
    }

    public void Update( Property property )
    {
        Property? exitingProperty = GetById( property.Id );

        if ( exitingProperty is null )
        {
            throw new InvalidOperationException( $"Property with id {property.Id} does not exit." );
        }

        exitingProperty.Name = property.Name;
        exitingProperty.Country = property.Country;
        exitingProperty.City = property.City;
        exitingProperty.Address = property.Address;
        exitingProperty.Latitude = property.Latitude;
        exitingProperty.Longitude = property.Longitude;
    }

    public void Delete( Guid id )
    {
        Property? exitingProperty = GetById( id );
        if ( exitingProperty is null )
        {
            throw new InvalidOperationException( $"Property with id {id} does not exit." );
        }

        _properties.Remove( exitingProperty );
    }
}