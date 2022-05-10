using Arquitectura.BL.Models;
using Arquitectura.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.BL.Services.Implements
{
    public class ProjectService : GenericService<Project>, IProjectService
    {
        private readonly IProjectRepository projectRepository;
        public ProjectService(IProjectRepository projectRepository) : base(projectRepository)
        {
            this.projectRepository = projectRepository;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await projectRepository.DeleteCheckOnEntity(id);
        }
    }
}
