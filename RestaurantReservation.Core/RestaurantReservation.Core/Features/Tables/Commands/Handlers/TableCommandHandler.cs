using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Restaurants.Commands.Models;
using RestaurantReservation.Core.Features.Tables.Commands.Models;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Services.Abstracts;
using RestaurantReservation.Services.Implementations;

namespace RestaurantReservation.Core.Features.Tables.Commands.Handlers;
public class TableCommandHandler : ResponseHandler,
                                   IRequestHandler<AddTableCommand, Response<Table>>,
                                   IRequestHandler<EditTableCommand, Response<Table>>,
                                   IRequestHandler<DeleteTableCommand, Response<string>>
{
    private readonly ITableService _tableService;
    private readonly IMapper _mapper;


    public TableCommandHandler(ITableService tableService, IMapper mapper)
    {
        _tableService = tableService;
        _mapper = mapper;
    }
    public async Task<Response<Table>> Handle(AddTableCommand request, CancellationToken cancellationToken)
    {
        var mapper = _mapper.Map<Table>(request);

        var result = await _tableService.AddTablesAsync(mapper);

        if (result is not null) return Created(result);
        return BadRequest<Table>(result);
    }

    public async Task<Response<Table>> Handle(EditTableCommand request, CancellationToken cancellationToken)
    {
        var mapper = _mapper.Map<Table>(request);

        var result = await _tableService.EditTablesAsync(mapper);

        if (result is not null) return Success(result);
        return BadRequest<Table>(result);
    }

    public async Task<Response<string>> Handle(DeleteTableCommand request, CancellationToken cancellationToken)
    {
        var table = await _tableService.GetByIDTableAsync(request.Id);

        if (table is null)
        {
            return NotFound<string>("Restaurant not found");
        }

        var deletionResult = await _tableService.DeleteAsync(table);

        if (deletionResult == "Success")
        {
            return Deleted<string>();
        }
        else
        {
            return BadRequest<string>("Failed to delete Table");
        }
    }
}
