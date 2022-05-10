using Arquitectura.BL.Data;
using Arquitectura.BL.DTOs;
using Arquitectura.BL.Models;
using Arquitectura.BL.Repositories.Implements;
using Arquitectura.BL.Services.Implements;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Arquitectura.API.Controllers
{
    [RoutePrefix("api/DocumentType")]
    public class DocumentTypeController : ApiController
    {
        private IMapper mapper;
        private readonly DocumentTypeService documentTypeService = new DocumentTypeService(new DocumentTypeRepository(ArquitecturaContext.Create()));
        public DocumentTypeController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        #region GetAll
        /// <summary>
        /// Obtiene los objetos tipo de documento
        /// </summary>
        /// <returns>Listado de objetos de tipo de documento</returns>
        /// <response code="200">OK. Devuelve el listado de objetos solicitados</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<DocumentTypeDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var documentTypes = await documentTypeService.GetAll();
            var documentTypeDTO = documentTypes.Select(x => mapper.Map<DocumentTypeDTO>(x));
            return Ok(documentTypeDTO);
        }
        #endregion
        #region GetById
        /// <summary>
        /// Obtiene un objeto por su Id
        /// </summary>
        /// <param name="id">Id del objeto </param>
        /// <returns>Objeto tipo de documento</returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado</response>
        [HttpGet]
        [ResponseType(typeof(StateDTO))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var documentType = await documentTypeService.GetById(id);
            if (documentType == null)
            {
                return NotFound();
            }
            var documentTypeDTO = mapper.Map<DocumentTypeDTO>(documentType);
            return Ok(documentTypeDTO);
        }
        #endregion
        #region Post
        /// <summary>
        /// Crea el objeto tipo de documento
        /// </summary>
        /// <param name="documentTypeDTO">Objeto</param>
        /// <returns>Objeto tipo de documento</returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// <response code="400">BadRequest.</response>
        /// <response code="500">InternalServerError.</response>
        [HttpPost]
        public async Task<IHttpActionResult> Post(DocumentTypeDTO documentTypeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                documentTypeDTO.DocumentTypeID = null;
                documentTypeDTO.Descriptions = documentTypeDTO.Descriptions.ToString().Trim();
                var documentType = mapper.Map<DocumentType>(documentTypeDTO);
                documentType = await documentTypeService.Insert(documentType);
                return Ok(documentType);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion
        #region Put
        /// <summary>
        /// Actualiza el objeto tipo de documento
        /// </summary>
        /// <param name="documentTypeDTO">Objeto</param>
        /// <param name="id">Id del objeto</param>
        /// <returns>objeto tipo de documento</returns>
        /// <response code="200">OK. Devuelve el objeto modificado</response>
        /// <response code="400">BadRequest.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError.</response>
        [HttpPut]
        public async Task<IHttpActionResult> Put(DocumentTypeDTO documentTypeDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (documentTypeDTO.DocumentTypeID != id)
                return BadRequest("Debe ingresar el campo DocumentTypeID");

            var flag = await documentTypeService.GetById(id);

            if (flag == null)
                return NotFound();
            try
            {
                var documentType = mapper.Map<DocumentType>(documentTypeDTO);
                documentType = await documentTypeService.Update(documentType);
                return Ok(documentType);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion
        #region Delete
        /// <summary>
        /// Elimina un objeto tipo de documento por su Id
        /// </summary>
        /// <param name="id">Id del objeto</param>
        /// <returns>Ok</returns>
        /// <response code="200">OK. Objeto eliminado</response>
        /// <response code="500">InternalServerError.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await documentTypeService.GetById(id);
            if (flag == null)
                return NotFound();
            try
            {
                if (!await documentTypeService.DeleteCheckOnEntity(id))
                    await documentTypeService.Delete(id);
                else
                    throw new Exception("ForeignKeys");
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion
    }
}
