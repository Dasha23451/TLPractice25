using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers;
[ApiController]
[Route( "api/[controller]" )]
public class PropertiesController : ControllerBase
{
    private readonly IPropertyService _propertyService;
    private readonly IMapper _mapper;

    public PropertiesController( IPropertyService propertyService, IMapper mapper )
    {
        _propertyService = propertyService;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PropertyDto>> GetAllProperties()
    {
        var properties = _propertyService.GetAllProperties();
        return Ok( _mapper.Map<IEnumerable<PropertyDto>>( properties ) );
    }

    [HttpGet( "{id}" )]
    public ActionResult<PropertyDto> GetPropertyById( Guid id )
    {
        var property = _propertyService.GetPropertyById( id );
        if ( property == null )
        {
            return NotFound();
        }
        return Ok( _mapper.Map<PropertyDto>( property ) );
    }

    [HttpPost]
    public ActionResult<PropertyDto> CreateProperty( [FromBody] CreatePropertyDto createPropertyDto )
    {
        var property = _mapper.Map<Property>( createPropertyDto );
        var createdProperty = _propertyService.CreateProperty( property );
        return CreatedAtAction( nameof( GetPropertyById ),
            new { id = createdProperty.Id },
            _mapper.Map<PropertyDto>( createdProperty ) );
    }

    [HttpPut( "{id}" )]
    public IActionResult UpdateProperty( Guid id, [FromBody] CreatePropertyDto updatePropertyDto )
    {
        var property = _propertyService.GetPropertyById( id );
        if ( property == null )
        {
            return NotFound();
        }

        _mapper.Map( updatePropertyDto, property );
        _propertyService.UpdateProperty( property );
        return NoContent();
    }

    [HttpDelete( "{id}" )]
    public IActionResult DeleteProperty( Guid id )
    {
        var property = _propertyService.GetPropertyById( id );
        if ( property == null )
        {
            return NotFound();
        }

        _propertyService.DeleteProperty( id );
        return NoContent();
    }
}