using MediatR;
using RestaurantReservation.Core.Features.Restaurants.Queries.Models;
using RestaurantReservation.Core.Features.Restaurants.Queries.Results;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Core.Features.Restaurants.Queries.Handlers
{
    public class RestaurantQueryHandler : IRequestHandler<GetRestaurantListQuery, List<GetRestaurantListResponse>>
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantQueryHandler(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public async Task<List<GetRestaurantListResponse>> Handle(GetRestaurantListQuery request, CancellationToken cancellationToken)
        {
            var res = await _restaurantService.GetAllRestaurantsAsync();
            return null;
        }
    }
}

