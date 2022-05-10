using Arquitectura.BL.Data;
using Arquitectura.BL.Models;
using Arquitectura.BL.Repositories.Implements;
using System.Threading.Tasks;

namespace Arquitectura.BL.Repositories
{
    public class InstructorRepository : GenericRepository<Instructor>, I_InstructorRepository
    {
        public InstructorRepository(ArquitecturaContext arquitecturaContext) : base(arquitecturaContext)
        {

        }

        public Task<bool> DeleteCheckOnEntity(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
