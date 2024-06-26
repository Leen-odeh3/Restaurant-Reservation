using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Services.Implementations;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CustomerService> _logger;

    public CustomerService(ICustomerRepository customerRepository,IMapper mapper ,ILogger<CustomerService> logger)
    {
        _logger = logger;
        _mapper=mapper;
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<Customer> AddAsync(Customer customer)
    {
        await _customerRepository.AddAsync(customer);
        return customer;
    }

    public async Task<string> DeleteAsync(Customer customer)
    {
        var trans = _customerRepository.BeginTransaction();
        try
        {
            await _customerRepository.DeleteAsync(customer);
            await trans.CommitAsync();
            return "Success";
        }
        catch (Exception ex)
        {
            await trans.RollbackAsync();
            _logger.LogError($"Error deleting customer: {ex.Message}");
            return "Failed";
        }
    }

    public async Task<Customer> EditAsync(Customer customer)
    {
        var existingCustomer = await _customerRepository.GetByIdAsync(customer.CustomerID);

        if (existingCustomer is null)
        {
            throw new Exception($"Customer with ID {customer.CustomerID} not found.");
        }

        _mapper.Map(customer, existingCustomer);
        await _customerRepository.UpdateAsync(existingCustomer);

        return existingCustomer;
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _customerRepository.GetListAsync();
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        return await _customerRepository.GetByIdAsync(id);
    }

    public async Task<bool> IsCustomerPhoneExist(string phone)
    {
        var result = await _customerRepository.GetTableNoTracking()
            .FirstOrDefaultAsync(x => x.CustomerPhoneNumber.Equals(phone));

        return result != null;
    }

    public async Task<bool> IsEmailExist(string email)
    {
        var result = await _customerRepository.GetTableNoTracking()
            .FirstOrDefaultAsync(x => x.Email.Equals(email));

        return result != null;
    }

}
