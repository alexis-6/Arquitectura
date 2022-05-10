using Arquitectura.BL.Models;
using Arquitectura.BL.Repositories;

namespace Arquitectura.BL.Services.Implements
{
    public class CourseInstructorService : GenericService<CourseInstructor>, ICourseInstructorService
    {
        public CourseInstructorService(ICourseInstructorRepository courseInstructorRepository) : base(courseInstructorRepository)
        {

        }
    }
}
