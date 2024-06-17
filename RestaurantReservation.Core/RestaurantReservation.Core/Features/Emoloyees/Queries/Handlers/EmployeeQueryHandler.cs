using AutoMapper;
using MediatR;
using RestaurantReservation.Core.Bases;
using RestaurantReservation.Core.Features.Emoloyees.Queries.Moldels;
using RestaurantReservation.Core.Features.Emoloyees.Queries.Results;
using RestaurantReservation.Services.Abstracts;


namespace RestaurantReservation.Core.Features.Emoloyees.Queries.Handlers
{
    internal class EmployeeQueryHandler : IRequestHandler<GetEmployeeListQuery, Response<List<GetEmployeeListResponse>>>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler; 

        public EmployeeQueryHandler(IEmployeeService employeeService, IMapper mapper, ResponseHandler responseHandler)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _responseHandler = responseHandler ?? throw new ArgumentNullException(nameof(responseHandler)); 
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
    }
}
