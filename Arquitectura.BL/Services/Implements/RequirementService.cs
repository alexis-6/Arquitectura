using Arquitectura.BL.Models;
using Arquitectura.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.BL.Services.Implements
{
    public class RequirementService : GenericService<Requirement>, IRequirementService
    {
        private readonly IRequirementRepository requirementRepository;
        public RequirementService(IRequirementRepository requirementRepository) : base(requirementRepository)
        {
            this.requirementRepository = requirementRepository;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await requirementRepository.DeleteCheckOnEntity(id);
        }
    }
}
