using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Restaurants.Queries.Models;
using RestaurantReservation.Core.Features.Restaurants.Queries.Results;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Core.Features.Restaurants.Queries.Handlers;

public class RestaurantQueryHandler : ResponseHandler,
                                     IRequestHandler<GetRestaurantListQuery, Response<List<GetRestaurantListResponse>>>,
                                     IRequestHandler<GetRestaurantByIDQuery, Response<GetRestaurantListResponse>>
{
    private readonly IRestaurantService _restaurantService;
    private readonly IMapper _mapper;

    public RestaurantQueryHandler(IRestaurantService restaurantService, IMapper mapper)
    {
        _restaurantService = restaurantService;
        _mapper = mapper;
    }

    public async Task<Response<List<GetRestaurantListResponse>>> Handle(GetRestaurantListQuery request, CancellationToken cancellationToken)
    {
        var result = await _restaurantService.GetAllRestaurantsAsync();
        var mappedResult = _mapper.Map<List<GetRestaurantListResponse>>(result);

        var response = Success(mappedResult);
        return response;
    }

    public async Task<Response<GetRestaurantListResponse>> Handle(GetRestaurantByIDQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantService.GetByIDRestaurantsAsync(request.Id);

        if (restaurant is null)
        {
            return NotFound<GetRestaurantListResponse>($"No restaurant found with Id: {request.Id}");
        }

        var mappedRestaurant = _mapper.Map<GetRestaurantListResponse>(restaurant);
        var response = Success(mappedRestaurant);
        return response;
    }
}
