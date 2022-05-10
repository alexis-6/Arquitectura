using Arquitectura.BL.Data;
using Arquitectura.BL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.BL.Repositories.Implements
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly ArquitecturaContext arquitecturaContext;
        public CustomerRepository(ArquitecturaContext arquitecturaContext) : base(arquitecturaContext)
        {
            this.arquitecturaContext = arquitecturaContext;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await arquitecturaContext.Customer.AnyAsync(x => x.CustomerID == id);
            return flag;
        }
    }
}
