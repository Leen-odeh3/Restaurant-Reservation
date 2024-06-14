using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Restaurants.Queries.Models;
using RestaurantReservation.Core.Features.Restaurants.Queries.Results;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Core.Features.Restaurants.Queries.Handlers
{
    public class RestaurantQueryHandler: ResponseHandler, IRequestHandler<GetRestaurantListQuery, Response<List<GetRestaurantListResponse>>>
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
            var ListMapper = _mapper.Map<List<GetRestaurantListResponse>>(result);

            var res = Success(ListMapper);
            return res;
        }
    }
}

