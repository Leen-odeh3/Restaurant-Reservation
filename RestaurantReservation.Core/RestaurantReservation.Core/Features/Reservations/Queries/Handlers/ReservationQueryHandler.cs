using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Reservations.Queries.Models;
using RestaurantReservation.Core.Features.Reservations.Queries.Results;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Services.Abstracts;


namespace RestaurantReservation.Core.Features.OrderItems.Queries.Handlers;

public class ReservationQueryHandler : ResponseHandler,
                                      IRequestHandler<GetReservationListQuery, List<GetReservationListResponse>>,
                                      IRequestHandler<GetReservationsByCustomerQuery, List<GetReservationListResponse>>

{
    private readonly IReservationService _reservationService;
    private readonly IMapper _mapper;

    public ReservationQueryHandler(IReservationService reservationService, IMapper mapper)
    {
        _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<GetReservationListResponse>> Handle(GetReservationListQuery request, CancellationToken cancellationToken)
    {
        var reservations = await _reservationService.GetAllAsync();
        var mappedReservations = _mapper.Map<List<GetReservationListResponse>>(reservations);
        return mappedReservations;
    }

    public async Task<List<GetReservationListResponse>> Handle(GetReservationsByCustomerQuery request, CancellationToken cancellationToken)
    {
        var reservations = await _reservationService.GetReservationsByCustomerId(request.CustomerId);
        var mappedReservations = _mapper.Map<List<GetReservationListResponse>>(reservations);
        return mappedReservations;
    }
}
