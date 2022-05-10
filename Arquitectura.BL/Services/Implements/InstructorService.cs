using Arquitectura.BL.Models;
using Arquitectura.BL.Repositories;

namespace Arquitectura.BL.Services.Implements
{
    public class InstructorService : GenericService<Instructor>, I_InstructorService
    {
        public InstructorService(I_InstructorRepository i_InstructorRepository) : base(i_InstructorRepository)
        {

        }
    }
}
