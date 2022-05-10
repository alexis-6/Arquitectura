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
    [RoutePrefix("api/Requirement")]
    public class RequirementController : ApiController
    {
        private IMapper mapper;
        private readonly RequirementService requirementService = new RequirementService(new RequirementRepository(ArquitecturaContext.Create()));
        public RequirementController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        #region GetAll
        /// <summary>
        /// Obtiene los objetos de requerimiento
        /// </summary>
        /// <returns>Listado de objetos de requerimientos</returns>
        /// <response code="200">OK. Devuelve el listado de objetos solicitados</response>
        [Route("GetAll")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<OutputRequirementDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var requirements = await requirementService.GetAll();
            var requirementDTO = requirements.Select(x => mapper.Map<OutputRequirementDTO>(x));
            return Ok(requirementDTO);
        }
        #endregion
        #region GetById
        /// <summary>
        /// Obtiene un objeto por su Id
        /// </summary>
        /// <param name="id">Id del objeto </param>
        /// <returns>Objeto requerimiento</returns>
        /// /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// /// <response code="404">NotFound. No se ha encontrado el objeto solicitado</response>
        [HttpGet]
        [ResponseType(typeof(OutputRequirementDTO))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var requirement = await requirementService.GetById(id);
            if (requirement == null)
            {
                return NotFound();
            }
            var requirementDTO = mapper.Map<OutputRequirementDTO>(requirement);
            return Ok(requirementDTO);
        }
        #endregion
        #region Post
        /// <summary>
        /// Crea el objeto requerimiento
        /// </summary>
        /// <param name="requirementDTO">Objeto</param>
        /// <returns>Objeto requerimiento</returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// <response code="400">BadRequest.</response>
        /// <response code="500">InternalServerError.</response>
        [HttpPost]
        public async Task<IHttpActionResult> Post(InputRequirementDTO requirementDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (requirementDTO.DevelopmentDate >= requirementDTO.TestingDate)
            {
                return BadRequest("La fecha DevelopmentDate debe ser menor que la fecha TestingDate");
            }

            try
            {
                requirementDTO.RequirementID = null;
                requirementDTO.Reach = requirementDTO.Reach.ToString().Trim();
                var requirement = mapper.Map<Requirement>(requirementDTO);
                requirement = await requirementService.Insert(requirement);
                return Ok(requirement);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion
        #region Post
        /// <summary>
        /// Actualiza el objeto requerimiento
        /// </summary>
        /// <param name="requirementDTO">Objeto</param>
        /// <param name="id">Id del objeto</param>
        /// <returns>objeto requerimiento</returns>
        /// <response code="200">OK. Devuelve el objeto modificado</response>
        /// <response code="400">BadRequest.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError.</response>
        [HttpPut]
        public async Task<IHttpActionResult> Put(InputRequirementDTO requirementDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (requirementDTO.RequirementID != id)
                return BadRequest("Debe ingresar el campo RequirementID");

            if (requirementDTO.DevelopmentDate >= requirementDTO.TestingDate)
            {
                return BadRequest("La fecha DevelopmentDate debe ser menor que la fecha TestingDate");
            }

            var flag = await requirementService.GetById(id);

            if (flag == null)
                return NotFound();
            try
            {
                var requirement = mapper.Map<Requirement>(requirementDTO);
                requirement = await requirementService.Update(requirement);
                return Ok(requirement);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion
        #region Delete
        /// <summary>
        /// Elimina un objeto requerimiento por su Id
        /// </summary>
        /// <param name="id">Id del objeto</param>
        /// <returns>Ok</returns>
        /// <response code="200">OK. Objeto eliminado</response>
        /// <response code="500">InternalServerError.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await requirementService.GetById(id);
            if (flag == null)
                return NotFound();
            try
            {
                if (!await requirementService.DeleteCheckOnEntity(id))
                    await requirementService.Delete(id);
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
