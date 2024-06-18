using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.OrderItems.Queries.Models;
using RestaurantReservation.Core.Features.OrderItems.Queries.Results;
using RestaurantReservation.Services.Abstracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestaurantReservation.Core.Features.Customers.Queries.Resultes;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Core.Features.OrderItems.Queries.Handlers
{
    public class OrderItemQueryHandler : ResponseHandler,
        IRequestHandler<GetOrderItemListQuery, Response<List<GetOrderItemListResponse>>>
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;

        public OrderItemQueryHandler(IOrderItemService orderItemService, IMapper mapper)
        {
            _orderItemService = orderItemService ?? throw new ArgumentNullException(nameof(orderItemService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<List<GetOrderItemListResponse>>> Handle(GetOrderItemListQuery request, CancellationToken cancellationToken)
        {       
                var orderItems = await _orderItemService.GetAllAsync();

                var response = _mapper.Map<List<GetOrderItemListResponse>>(orderItems);

                return Success(response);
           
        }
    }
}
