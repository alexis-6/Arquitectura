using Arquitectura.BL.Data;
using Arquitectura.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arquitectura.BL.Repositories.Implements;
using System.Data.Entity;

namespace Arquitectura.BL.Repositories
{
    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        private readonly ArquitecturaContext arquitecturaContext;
        public StateRepository(ArquitecturaContext arquitecturaContext) : base(arquitecturaContext)
        {
            this.arquitecturaContext = arquitecturaContext;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await arquitecturaContext.State.AnyAsync(x => x.StateID == id);
            return flag;
        }
    }
}
