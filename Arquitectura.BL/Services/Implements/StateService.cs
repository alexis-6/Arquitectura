using Arquitectura.BL.Models;
using Arquitectura.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.BL.Services.Implements
{
    public class StateService : GenericService<State>, IStateService
    {
        private readonly IStateRepository stateRepository;
        public StateService(IStateRepository stateRepository) : base(stateRepository)
        {
            this.stateRepository = stateRepository;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await stateRepository.DeleteCheckOnEntity(id);
        }
    }
}
