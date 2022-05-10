using Arquitectura.BL.Models;
using Arquitectura.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.BL.Services.Implements
{
    public  class CustomerService : GenericService<Customer>, ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await customerRepository.DeleteCheckOnEntity(id);
        }
    }
}
