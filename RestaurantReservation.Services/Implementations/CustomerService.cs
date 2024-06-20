using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using RestaurantReservation.Infrustructure.Abstracts;
using RestaurantReservation.Services.Abstracts;

namespace RestaurantReservation.Services.Implementations;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
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
            Console.WriteLine($"Error deleting customer: {ex.Message}");
            return "Failed";
        }
    }

    public async Task<Customer> EditAsync(Customer customer)
    {
        var existingCustomer = await _customerRepository.GetByIdAsync(customer.CustomerID);

        if (existingCustomer != null)
        {
            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.CustomerPhoneNumber = customer.CustomerPhoneNumber;

            await _customerRepository.UpdateAsync(existingCustomer);

            return existingCustomer;
        }
        else
        {
            throw new Exception("Customer not found");
        }
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _customerRepository.GetListAsync();
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        return await _customerRepository.GetByIdAsync(id);
    }

    public async Task<bool> IsCustomerPhoneExist(string phone, int id)
    {
        var result = await _customerRepository.GetTableNoTracking()
             .FirstOrDefaultAsync(x => x.CustomerPhoneNumber.Equals(phone) && !x.CustomerID.Equals(id));

        return result != null;
    }

    public async Task<bool> IsEmailExist(string email, int id)
    {
        var result = await _customerRepository.GetTableNoTracking()
            .FirstOrDefaultAsync(x => x.Email.Equals(email) && !x.CustomerID.Equals(id));

        return result != null;
    }
}
