using Arquitectura.BL.Models;
using Arquitectura.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.BL.Services.Implements
{
    public class DeveloperService : GenericService<Developer>, IDeveloperService
    {
        private readonly IDeveloperRepository developerRepository;
        public DeveloperService(IDeveloperRepository developerRepository) : base(developerRepository)
        {
            this.developerRepository = developerRepository;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await developerRepository.DeleteCheckOnEntity(id);
        }
    }
}
