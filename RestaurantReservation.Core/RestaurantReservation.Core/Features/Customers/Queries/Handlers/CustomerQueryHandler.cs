using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Customers.Queries.Models;
using RestaurantReservation.Core.Features.Customers.Queries.Resultes;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Core.Features.Customers.Queries.Handlers;
   public class CustomerQueryHandler : ResponseHandler,
                                         IRequestHandler<GetCustomerListQuery, Response<List<GetCustomerListResponse>>>
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerQueryHandler(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<Response<List<GetCustomerListResponse>>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerService.GetAllAsync();
            var mappedCustomers = _mapper.Map<List<GetCustomerListResponse>>(customers);
            return Success(mappedCustomers);
        } 
    }


