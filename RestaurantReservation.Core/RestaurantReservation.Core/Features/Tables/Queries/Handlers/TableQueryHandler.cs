using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Tables.Queries.Models;
using RestaurantReservation.Core.Features.Tables.Queries.Results;
using RestaurantReservation.Services.Abstracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantReservation.Core.Features.Tables.Queries.Handlers
{
    public class TableQueryHandler : ResponseHandler,
                                     IRequestHandler<GetTableListQuery, Response<List<GetTableListResponse>>>
    {
        private readonly ITableService _tableService;
        private readonly IMapper _mapper;

        public TableQueryHandler(ITableService tableService, IMapper mapper)
        {
            _tableService = tableService;
            _mapper = mapper;
        }

        public async Task<Response<List<GetTableListResponse>>> Handle(GetTableListQuery request, CancellationToken cancellationToken)
        {
            var result = await _tableService.GetAllTablesAsync();
            var mappedResult = _mapper.Map<List<GetTableListResponse>>(result);
            var response = Success(mappedResult);
            return response;
        }
    }
}
