using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers;
[ApiController]
[Route( "api/properties/{propertyId}/[controller]" )]
public class RoomTypesController : ControllerBase
{
    private readonly IRoomTypeService _roomTypeService;
    private readonly IMapper _mapper;

    public RoomTypesController( IRoomTypeService roomTypeService, IMapper mapper )
    {
        _roomTypeService = roomTypeService;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<RoomTypeDto>> GetRoomTypesForProperty( Guid propertyId )
    {
        var roomTypes = _roomTypeService.GetRoomTypesForProperty( propertyId );
        return Ok( _mapper.Map<IEnumerable<RoomTypeDto>>( roomTypes ) );
    }

    [HttpGet( "{id}", Name = "GetRoomTypeById" )]
    public ActionResult<RoomTypeDto> GetRoomTypeById( Guid id )
    {
        var roomType = _roomTypeService.GetRoomTypeById( id );
        if ( roomType == null )
        {
            return NotFound();
        }
        return Ok( _mapper.Map<RoomTypeDto>( roomType ) );
    }

    [HttpPost]
    public IActionResult CreateRoomType(
        Guid propertyId, [FromBody] CreateRoomTypeDto createRoomTypeDto )
    {
        var roomType = _mapper.Map<RoomType>( createRoomTypeDto );
        roomType.PropertyId = propertyId;

        var createdRoomType = _roomTypeService.CreateRoomType( roomType );
        return CreatedAtRoute( nameof( GetRoomTypeById ),
            new { propertyId, id = createdRoomType.Id },
            _mapper.Map<RoomTypeDto>( createdRoomType ) );
    }

    [HttpPut( "{id}" )]
    public IActionResult UpdateRoomType( Guid id, [FromBody] CreateRoomTypeDto updateRoomTypeDto )
    {
        var roomType = _roomTypeService.GetRoomTypeById( id );
        if ( roomType == null )
        {
            return NotFound();
        }

        _mapper.Map( updateRoomTypeDto, roomType );
        _roomTypeService.UpdateRoomType( roomType );
        return NoContent();
    }

    [HttpDelete( "{id}" )]
    public IActionResult DeleteRoomType( Guid id )
    {
        var roomType = _roomTypeService.GetRoomTypeById( id );
        if ( roomType == null )
        {
            return NotFound();
        }

        _roomTypeService.DeleteRoomType( id );
        return NoContent();
    }
}