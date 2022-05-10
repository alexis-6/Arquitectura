using Arquitectura.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.BL.Repositories
{
    public interface IStateRepository : IGenericRepository<State>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
