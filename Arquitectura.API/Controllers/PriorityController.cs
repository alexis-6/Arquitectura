using Arquitectura.BL.Services.Implements;
using AutoMapper;
using System;
using Arquitectura.BL.Data;
using Arquitectura.BL.DTOs;
using Arquitectura.BL.Models;
using Arquitectura.BL.Repositories;
using Arquitectura.BL.Repositories.Implements;
using Arquitectura.BL.Services.Implements;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Arquitectura.API.Controllers
{
    [RoutePrefix("api/Priority")]
    public class PriorityController : ApiController
    {
        private IMapper mapper;
        private readonly PriorityService priorityService = new PriorityService(new PriorityRepository(ArquitecturaContext.Create()));
        public PriorityController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        #region GetAll
        /// <summary>
        /// Obtiene los objetos prioridad
        /// </summary>
        /// <returns>Listado de objetos de prioridades</returns>
        /// <response code="200">OK. Devuelve el listado de objetos solicitados</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<PriorityDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var prioritys = await priorityService.GetAll();
            var prioritysDTO = prioritys.Select(x => mapper.Map<PriorityDTO>(x));
            return Ok(prioritysDTO);
        }
        #endregion
        #region GetById
        /// <summary>
        /// Obtiene un objeto por su Id
        /// </summary>
        /// <param name="id">Id del objeto </param>
        /// <returns>Objeto curso</returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado</response>
        [HttpGet]
        [ResponseType(typeof(PriorityDTO))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var priority = await priorityService.GetById(id);
            if (priority == null)
            {
                return NotFound();
            }
            var priorityDTO = mapper.Map<PriorityDTO>(priority);
            return Ok(priorityDTO);
        }
        #endregion
        #region Post
        /// <summary>
        /// Crea el objeto prioridad
        /// </summary>
        /// <param name="priorityDTO">Objeto</param>
        /// <returns>Objeto prioridad</returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// <response code="400">BadRequest.</response>
        /// <response code="500">InternalServerError.</response>
        [HttpPost]
        public async Task<IHttpActionResult> Post(PriorityDTO priorityDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                priorityDTO.PriorityID = null;
                priorityDTO.Descriptions = priorityDTO.Descriptions.ToString().Trim();
                var priority = mapper.Map<Priority>(priorityDTO);
                priority = await priorityService.Insert(priority);
                return Ok(priority);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion
        #region Put
        /// <summary>
        /// Actualiza el objeto prioridad
        /// </summary>
        /// <param name="priorityDTO">Objeto</param>
        /// <param name="id">Id del objeto</param>
        /// <returns>objeto prioridad</returns>
        /// <response code="200">OK. Devuelve el objeto modificado</response>
        /// <response code="400">BadRequest.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError.</response>
        [HttpPut]
        public async Task<IHttpActionResult> Put(PriorityDTO priorityDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (priorityDTO.PriorityID != id)
                return BadRequest("Debe ingresar el campo PriorityID");

            var flag = await priorityService.GetById(id);

            if (flag == null)
                return NotFound();
            try
            {
                var priority = mapper.Map<Priority>(priorityDTO);
                priority = await priorityService.Update(priority);
                return Ok(priority);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion
        #region Delete
        /// <summary>
        /// Elimina un objeto prioridad por su Id
        /// </summary>
        /// <param name="id">Id del objeto</param>
        /// <returns>Ok</returns>
        /// <response code="200">OK. Objeto eliminado</response>
        /// <response code="500">InternalServerError.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await priorityService.GetById(id);
            if (flag == null)
                return NotFound();
            try
            {
                if (!await priorityService.DeleteCheckOnEntity(id))
                    await priorityService.Delete(id);
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
