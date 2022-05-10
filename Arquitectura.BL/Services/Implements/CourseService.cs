using Arquitectura.BL.Models;
using Arquitectura.BL.Repositories;
using System.Threading.Tasks;

namespace Arquitectura.BL.Services.Implements
{
    public class CourseService : GenericService<Course>, ICourseService
    {
        private readonly ICourseRepository courseRepository;
        public CourseService(ICourseRepository courseRepository) : base(courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await courseRepository.DeleteCheckOnEntity(id);
        }
    }
}
