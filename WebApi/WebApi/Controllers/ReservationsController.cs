using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers;
[ApiController]
[Route( "api/[controller]" )]
public class ReservationsController : ControllerBase
{
    private readonly IReservationService _reservationService;
    private readonly IMapper _mapper;

    public ReservationsController( IReservationService reservationService, IMapper mapper )
    {
        _reservationService = reservationService;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ReservationDto>> GetAllReservations(
        [FromQuery] Guid? propertyId,
        [FromQuery] DateTime? fromDate,
        [FromQuery] DateTime? toDate,
        [FromQuery] string? guestName )
    {
        var reservations = _reservationService.SearchReservations(
            propertyId, fromDate, toDate, guestName );
        return Ok( _mapper.Map<IEnumerable<ReservationDto>>( reservations ) );
    }

    [HttpGet( "{id}" )]
    public ActionResult<ReservationDto> GetReservationById( Guid id )
    {
        var reservation = _reservationService.GetReservationById( id );
        if ( reservation == null )
        {
            return NotFound();
        }
        return Ok( _mapper.Map<ReservationDto>( reservation ) );
    }

    [HttpGet( "search" )]
    public ActionResult<IEnumerable<AvailableRoomTypeDto>> SearchAvailability(
        [FromQuery] SearchAvailabilityDto searchDto )
    {
        var availableRoomTypes = _reservationService.SearchAvailableRoomTypes(
            searchDto.City,
            searchDto.ArrivalDate,
            searchDto.DepartureDate,
            searchDto.Guests,
            searchDto.MaxPrice );

        return Ok( _mapper.Map<IEnumerable<AvailableRoomTypeDto>>( availableRoomTypes ) );
    }

    [HttpPost]
    public ActionResult<ReservationDto> CreateReservation( [FromBody] CreateReservationDto createReservationDto )
    {
        var reservation = _mapper.Map<Reservation>( createReservationDto );
        var createdReservation = _reservationService.CreateReservation( reservation );
        return CreatedAtAction( nameof( GetReservationById ),
            new { id = createdReservation.Id },
            _mapper.Map<ReservationDto>( createdReservation ) );
    }

    [HttpDelete( "{id}" )]
    public IActionResult CancelReservation( Guid id )
    {
        var reservation = _reservationService.GetReservationById( id );
        if ( reservation == null )
        {
            return NotFound();
        }

        _reservationService.DeleteReservation( id );
        return NoContent();
    }
}