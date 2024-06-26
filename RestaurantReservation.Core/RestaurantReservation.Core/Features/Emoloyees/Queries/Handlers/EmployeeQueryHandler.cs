using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Emoloyees.Queries.Moldels;
using RestaurantReservation.Core.Features.Emoloyees.Queries.Results;
using RestaurantReservation.Core.Features.Emoloyees.Queries.Resultsl;
using RestaurantReservation.Core.Wrappers;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Core.Features.Emoloyees.Queries.Handlers
{
    internal class EmployeeQueryHandler : 
         IRequestHandler<GetEmployeeListQuery, Response<List<GetEmployeeListResponse>>>,
         IRequestHandler<GetListAllManagers, Response<List<GetEmployeeListResponse>>>,
         IRequestHandler<GetEmployeeAverageOrderAmountQuery, decimal>,
         IRequestHandler<GetEmployeePaginatedListQuery, PaginatedResult<GetEmployeePaginatedListResponse>>

{
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        private readonly IOrderService _orderService;
        public EmployeeQueryHandler(IEmployeeService employeeService, IMapper mapper, 
            ResponseHandler responseHandler, IOrderService orderService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _responseHandler = responseHandler ?? throw new ArgumentNullException(nameof(responseHandler));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));

        }
        public async Task<Response<List<GetEmployeeListResponse>>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var employees = await _employeeService.GetAllAsync();
                var mappedEmployees = _mapper.Map<List<GetEmployeeListResponse>>(employees);

                return _responseHandler.Success(mappedEmployees);
            }
            catch (Exception ex)
            {
                return _responseHandler.Fail<List<GetEmployeeListResponse>>($"Failed to retrieve employees: {ex.Message}");
            }
        }

        public async Task<PaginatedResult<GetEmployeePaginatedListResponse>> Handle(GetEmployeePaginatedListQuery request, CancellationToken cancellationToken)
        {
            var FilterQuery = _employeeService.FilterPaginatedQuerable((Domain.Enums.OrderingEnum)request.OrderBy, request.Search);
            var PaginatedList = await _mapper.ProjectTo<GetEmployeePaginatedListResponse>(FilterQuery).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            PaginatedList.Meta = new { Count = PaginatedList.Data.Count() };
            return PaginatedList;
        }

        public async Task<Response<List<GetEmployeeListResponse>>> Handle(GetListAllManagers request, CancellationToken cancellationToken)
        {
            try
            {
                var employees = await _employeeService.GetallManagers();
                var mappedEmployees = _mapper.Map<List<GetEmployeeListResponse>>(employees);

                return _responseHandler.Success(mappedEmployees);
            }
            catch (Exception ex)
            {
                return _responseHandler.Fail<List<GetEmployeeListResponse>>($"Failed to retrieve employees: {ex.Message}");
            }
        }
        public async Task<decimal> Handle(GetEmployeeAverageOrderAmountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var orders = await _orderService.GetOrdersByEmployeeId(request.EmployeeId);

                if (orders.Any())
                {
                    var averageOrderAmount = orders.Average(o => o.TotalAmount);
                    return averageOrderAmount;
                }

                throw new Exception("No orders found for the employee.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve orders: {ex.Message}", ex);
            }
        }
    }
    }

