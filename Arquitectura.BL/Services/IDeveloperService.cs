using Arquitectura.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.BL.Services
{
    public interface IDeveloperService : IGenericService<Developer>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
