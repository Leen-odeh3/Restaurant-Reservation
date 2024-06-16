using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.MenuItems.Commands.Models;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Core.Features.MenuItems.Commands.Handlers;
public class MenuItemCommandHandler : ResponseHandler,
                                        IRequestHandler<AddMenuItemCommand, Response<MenuItem>>,
                                        IRequestHandler<EditMenuItemCommand, Response<MenuItem>>,
                                        IRequestHandler<DeleteMenuItemCommand, Response<string>>
{
    private readonly IMenuItemService _menuItemService;
    private readonly IMapper _mapper;

    public MenuItemCommandHandler(IMenuItemService menuItemService, IMapper mapper)
    {
        _menuItemService = menuItemService;
        _mapper = mapper;
    }

    public async Task<Response<MenuItem>> Handle(AddMenuItemCommand request, CancellationToken cancellationToken)
    {
        var mappedItem = _mapper.Map<MenuItem>(request);

        var result = await _menuItemService.AddAsync(mappedItem);

        if (result != null)
            return Created(result);

        return BadRequest<MenuItem>(result);
    }

    public async Task<Response<MenuItem>> Handle(EditMenuItemCommand request, CancellationToken cancellationToken)
    {
        var mappedItem = _mapper.Map<MenuItem>(request);

        var result = await _menuItemService.EditAsync(mappedItem);

        if (result != null)
            return Success(result);

        return BadRequest<MenuItem>(result);
    }

    public async Task<Response<string>> Handle(DeleteMenuItemCommand request, CancellationToken cancellationToken)
    {
        var menuItem = await _menuItemService.GetByIdAsync(request.Id);

        if (menuItem == null)
            return NotFound<string>("Menu item not found");

        var deletionResult = await _menuItemService.DeleteAsync(menuItem);

        if (deletionResult == "Success")
            return Deleted<string>();

        return BadRequest<string>("Failed to delete menu item");
    }
}

