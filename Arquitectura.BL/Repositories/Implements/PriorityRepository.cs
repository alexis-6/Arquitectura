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
    public class PriorityRepository : GenericRepository<Priority>, IPriorityRepository
    {
        private readonly ArquitecturaContext arquitecturaContext;
        public PriorityRepository(ArquitecturaContext arquitecturaContext) : base(arquitecturaContext)
        {
            this.arquitecturaContext = arquitecturaContext;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await arquitecturaContext.Priority.AnyAsync(x => x.PriorityID == id);
            return flag;
        }
    }
}
