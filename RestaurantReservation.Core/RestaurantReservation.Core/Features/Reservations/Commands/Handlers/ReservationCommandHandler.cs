using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Reservations.Commands.Models;
using RestaurantReservation.Core.FeaturesReservations.Commands.Models;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Core.Features.Reservations.Commands.Handlers;
public class ReservationCommandHandler : ResponseHandler,
    IRequestHandler<AddReservationCommand, Response<Reservation>>,
    IRequestHandler<EditReservationCommand, Response<Reservation>>,
    IRequestHandler<DeleteReservationCommand, Response<string>>
{
    private readonly IReservationService _reservationService;
    private readonly IMapper _mapper;

    public ReservationCommandHandler(IReservationService reservationService, IMapper mapper)
    {
        _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Response<Reservation>> Handle(AddReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = _mapper.Map<Reservation>(request);

        try
        {
            var result = await _reservationService.AddAsync(reservation);
            return Success(result);
        }
        catch (Exception ex)
        {
            return Fail<Reservation>($"Failed to add Reservation: {ex.Message}");
        }
    }

    public async Task<Response<Reservation>> Handle(EditReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = _mapper.Map<Reservation>(request);

        try
        {
            var result = await _reservationService.EditAsync(reservation);
            return Success(result);
        }
        catch (Exception ex)
        {
            return Fail<Reservation>($"Failed to update Reservation: {ex.Message}");
        }
    }

    public async Task<Response<string>> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationService.GetByIdAsync(request.ReservationID);

        if (reservation == null)
            return NotFound<string>($"No reservation found with Id: {request.ReservationID}");

        try
        {
            var deletionResult = await _reservationService.DeleteAsync(reservation);
            return Success("Reservation deleted successfully");
        }
        catch (Exception ex)
        {
            return Fail<string>($"Failed to delete Reservation: {ex.Message}");
        }
    }

    
}
