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
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly ArquitecturaContext arquitecturaContext;
        public ProjectRepository(ArquitecturaContext arquitecturaContext) : base(arquitecturaContext)
        {
            this.arquitecturaContext = arquitecturaContext;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await arquitecturaContext.Project.AnyAsync(x => x.ProjectID == id);
            return flag;
        }
    }
}
