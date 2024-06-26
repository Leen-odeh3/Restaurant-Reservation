using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Orders.Queries.Models;
using RestaurantReservation.Core.Features.Orders.Queries.Results;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Core.Features.Orders.Queries.Handlers;
public class OrderQueryHandler : ResponseHandler,
                                   IRequestHandler<GetOrderListQuery, Response<List<GetOrderListResponse>>>
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrderQueryHandler(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    public async Task<Response<List<GetOrderListResponse>>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
    {
        var result = await _orderService.GetAllAsync();
        var mappedResult = _mapper.Map<List<GetOrderListResponse>>(result);

        var response = Success(mappedResult);
        return response;
    }
}