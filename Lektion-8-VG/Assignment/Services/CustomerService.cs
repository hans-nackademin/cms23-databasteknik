using Assignment.Entities;
using Assignment.Models;
using Assignment.Repositories;

namespace Assignment.Services;

public interface ICustomerService
{
    Task<bool> CreateCustomerAsync(CustomerRegistrationForm form);
    Task<IEnumerable<CustomerEntity>> GetAllAsync();
}

public class CustomerService : ICustomerService
{
    private readonly IAddressRepository _addressRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerTypeRepository _customerTypeRepository;

    public CustomerService(IAddressRepository addressRepository, ICustomerRepository customerRepository, ICustomerTypeRepository customerTypeRepository)
    {
        _addressRepository = addressRepository;
        _customerRepository = customerRepository;
        _customerTypeRepository = customerTypeRepository;
    }

    public async Task<bool> CreateCustomerAsync(CustomerRegistrationForm form)
    {
        // check customer
        if (!await _customerRepository.ExistsAsync(x => x.Email == form.Email))
        {
            // check address
            AddressEntity addressEntity = await _addressRepository.GetAsync(x => x.StreetName == form.StreetName && x.PostalCode == form.PostalCode);
            addressEntity ??= await _addressRepository.CreateAsync(new AddressEntity { StreetName = form.StreetName, PostalCode = form.PostalCode, City = form.City });

            // check customer type
            CustomerTypeEntity customerTypeEntity = await _customerTypeRepository.GetAsync(x => x.CustomerTypeName == form.CustomerType);
            customerTypeEntity ??= await _customerTypeRepository.CreateAsync(new CustomerTypeEntity { CustomerTypeName = form.CustomerType });


            // create customer
            CustomerEntity customerEntity = await _customerRepository.CreateAsync(
                new CustomerEntity
                {
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    Email = form.Email,
                    AddressId = addressEntity.Id,
                    CustomerTypeId = customerTypeEntity.Id
                });

            if (customerEntity != null)
                return true;

        }

        return false;

    }

    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return customers;
    }
}
