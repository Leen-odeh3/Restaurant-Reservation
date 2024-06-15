using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Restaurants.Commands.Models;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Core.Features.Restaurants.Commands.Handlers;
public class RestaurantCommandHandler : ResponseHandler, 
                                        IRequestHandler<AddRestaurantCommand, Response<Restaurant>>,
                                        IRequestHandler<EditRestaurantCommand, Response<Restaurant>>,
                                        IRequestHandler<DeleteRestaurantCommand, Response<String>>
{
    private readonly IRestaurantService _restaurantService;
    private readonly IMapper _mapper;


    public RestaurantCommandHandler(IRestaurantService restaurantService,IMapper mapper)
    {
        _restaurantService = restaurantService;
        _mapper = mapper;
    }

    public async Task<Response<Restaurant>> Handle(AddRestaurantCommand request, CancellationToken cancellationToken)
    {
        var mapper = _mapper.Map<Restaurant>(request);

        var result = await _restaurantService.AddRestaurantsAsync(mapper);

        if (result is not null) return Created(result);
        return BadRequest<Restaurant>(result);
    }

    public async Task<Response<Restaurant>> Handle(EditRestaurantCommand request, CancellationToken cancellationToken)
    {
        var mapper = _mapper.Map<Restaurant>(request);

        var result = await _restaurantService.EditRestaurantsAsync(mapper);

        if (result is not null) return Success(result);
        return BadRequest<Restaurant>(result);
    }
    public async Task<Response<string>> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantService.GetByIDRestaurantsAsync(request.Id);

        if (restaurant == null)
        {
            return NotFound<string>("Restaurant not found");
        }

        var deletionResult = await _restaurantService.DeleteAsync(restaurant);

        if (deletionResult == "Success")
        {
            return Deleted<string>();
        }
        else
        {
            return BadRequest<string>("Failed to delete restaurant");
        }
    }
}
