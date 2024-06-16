﻿using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Tables.Commands.Models;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Core.Features.Tables.Commands.Handlers;
public class TableCommandHandler : ResponseHandler,
                                   IRequestHandler<AddTableCommand, Response<Table>>
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
}
