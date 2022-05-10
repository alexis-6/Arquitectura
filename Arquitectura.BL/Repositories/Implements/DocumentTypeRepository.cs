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
    public class DocumentTypeRepository : GenericRepository<DocumentType>, IDocumentTypeRepository
    {
        private readonly ArquitecturaContext arquitecturaContext;
        public DocumentTypeRepository(ArquitecturaContext arquitecturaContext) : base(arquitecturaContext)
        {
            this.arquitecturaContext = arquitecturaContext;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await arquitecturaContext.DocumentType.AnyAsync(x => x.DocumentTypeID == id);
            return flag;
        }
    }
}
