using Arquitectura.BL.Models;
using Arquitectura.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.BL.Services.Implements
{
    public class DocumentTypeService : GenericService<DocumentType>, IDocumentTypeService
    {
        private readonly IDocumentTypeRepository documentTypeRepository;
        public DocumentTypeService(IDocumentTypeRepository documentTypeRepository) : base(documentTypeRepository)
        {
            this.documentTypeRepository = documentTypeRepository;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await documentTypeRepository.DeleteCheckOnEntity(id);
        }
    }
}
