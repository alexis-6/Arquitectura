using Arquitectura.BL.Data;
using Arquitectura.BL.Models;

namespace Arquitectura.BL.Repositories.Implements
{
    public class CourseInstructorRepository : GenericRepository<CourseInstructor>, ICourseInstructorRepository
    {
        public CourseInstructorRepository(ArquitecturaContext arquitecturaContext) : base(arquitecturaContext)
        {

        }
    }
}
