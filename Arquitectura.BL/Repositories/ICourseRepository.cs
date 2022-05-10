using Arquitectura.BL.Models;
using System.Threading.Tasks;

namespace Arquitectura.BL.Repositories
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
