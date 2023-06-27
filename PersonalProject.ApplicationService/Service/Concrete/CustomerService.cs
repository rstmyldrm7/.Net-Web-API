using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalProject.ApiContract;
using PersonalProject.ApiContract.Request;
using PersonalProject.ApiContract.Response;
using PersonalProject.ApplicationService.Communicator.Abstract;
using PersonalProject.ApplicationService.Service.Abstract;
using PersonalProject.Domain;
using PersonalProject.Domain.Aggregate;
using PersonalProject.Domain.Aggregate.Repositories;


namespace PersonalProject.ApplicationService.Service.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IKimlikCommunicator _kimlikCommunicator;
        private readonly IDbContextHandler _dbContextHandler;

        public CustomerService(ICustomerRepository customerRepository, IDbContextHandler dbContextHandler, IKimlikCommunicator kimlikCommunicator)
        {
            _customerRepository = customerRepository;
            _dbContextHandler = dbContextHandler;
            _kimlikCommunicator = kimlikCommunicator;
        }
        public async Task<ResponseBase<CreateCustomerResponse>> CreateCustomer(CreateCustomerRequest request)
        {
            var customer = new Customer(request.Name, request.SurName, request.BirthDate, request.IdentityNo, false);
            await _customerRepository.SaveAsync(customer);
            await _dbContextHandler.SaveChangesAsync();

            var verified = await _kimlikCommunicator.VerifyIdentity(request.IdentityNo, request.Name, request.SurName, request.BirthDate);
            if (verified)
            {
                customer.SetIdentityNoVerified(true);
                _customerRepository.Update(customer);
                await _dbContextHandler.SaveChangesAsync();
            }

            return new ResponseBase<CreateCustomerResponse>
            {
                Success = true,
                Data = new CreateCustomerResponse()
                {
                    Customer = customer
                }
            };
        }
    }
}
