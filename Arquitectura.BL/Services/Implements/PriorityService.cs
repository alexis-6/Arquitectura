using Arquitectura.BL.Models;
using Arquitectura.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.BL.Services.Implements
{
    public class PriorityService : GenericService<Priority>, IPrioritaryService
    {
        private readonly IPriorityRepository priorityRepository;
        public PriorityService(IPriorityRepository priorityRepository) : base(priorityRepository)
        {
            this.priorityRepository = priorityRepository;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await priorityRepository.DeleteCheckOnEntity(id);
        }
    }
}
