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
    public class RequirementRepository : GenericRepository<Requirement>, IRequirementRepository
    {
        private readonly ArquitecturaContext arquitecturaContext;
        public RequirementRepository(ArquitecturaContext arquitecturaContext) : base(arquitecturaContext)
        {
            this.arquitecturaContext = arquitecturaContext;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await arquitecturaContext.Requirement.AnyAsync(x => x.RequirementID == id);
            return flag;
        }
    }
}
