using Arquitectura.BL.Data;
using Arquitectura.BL.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Arquitectura.BL.Repositories.Implements
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly ArquitecturaContext arquitecturaContext;
        public CourseRepository(ArquitecturaContext arquitecturaContext) : base(arquitecturaContext)
        {
            this.arquitecturaContext = arquitecturaContext;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await arquitecturaContext.Course.AnyAsync(x => x.CourseID == id);
            return flag;
        }
    }
}
