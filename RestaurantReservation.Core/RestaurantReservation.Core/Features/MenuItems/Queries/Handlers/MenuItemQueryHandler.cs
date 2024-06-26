using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.MenuItems.Queries.Models;
using RestaurantReservation.Core.Features.MenuItems.Queries.Results;
using RestaurantReservation.Services.Abstracts;
namespace RestaurantReservation.Core.Features.MenuItems.Queries.Handlers;

internal class MenuItemQueryHandler : ResponseHandler,
                                          IRequestHandler<GetMenuItemListQuery, Response<List<GetMenuItemListResponse>>>
{
    private readonly IMenuItemService _menuItemService;
    private readonly IMapper _mapper;

    public MenuItemQueryHandler(IMenuItemService menuItemService, IMapper mapper)
    {
        _menuItemService = menuItemService;
        _mapper = mapper;
    }

    public async Task<Response<List<GetMenuItemListResponse>>> Handle(GetMenuItemListQuery request, CancellationToken cancellationToken)
    {
        var result = await _menuItemService.GetAllAsync();
        var mappedResult = _mapper.Map<List<GetMenuItemListResponse>>(result);

        var response = Success(mappedResult);
        return response;
    }

}