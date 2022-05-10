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
    [RoutePrefix("api/States")]
    public class StatesController : ApiController
    {
        private IMapper mapper;
        private readonly StateService stateService = new StateService(new StateRepository(ArquitecturaContext.Create()));
        public StatesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        /// <summary>
        /// Obtiene los objetos de estados
        /// </summary>
        /// <returns>Listado de objetos de estados</returns>
        /// <response code="200">OK. Devuelve el listado de objetos solicitados</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<StateDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var states = await stateService.GetAll();
            var statesDTO = states.Select(x => mapper.Map<StateDTO>(x));
            return Ok(statesDTO);
        }
        /// <summary>
        /// Obtiene un objeto por su Id
        /// </summary>
        /// <param name="id">Id del objeto </param>
        /// <returns>Objeto estado</returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado</response>
        [HttpGet]
        [ResponseType(typeof(StateDTO))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var state = await stateService.GetById(id);
            if (state == null)
            {
                return NotFound();
            }
            var stateDTO = mapper.Map<StateDTO>(state);
            return Ok(stateDTO);
        }
        /// <summary>
        /// Crear el objeto estado
        /// </summary>
        /// <param name="stateDTO">Objeto</param>
        /// <returns>Objeto estado</returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// <response code="400">BadRequest.</response>
        /// <response code="500">InternalServerError.</response>
        [HttpPost]
        public async Task<IHttpActionResult> Post(StateDTO stateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                stateDTO.StateID = null;
                stateDTO.Descriptions = stateDTO.Descriptions.ToString().Trim();
                var state = mapper.Map<State>(stateDTO);
                state = await stateService.Insert(state);
                return Ok(state);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Actualiza el objeto estado
        /// </summary>
        /// <param name="stateDTO"> Objeto</param>
        /// <param name="id"> Id del objeto</param>
        /// <returns>objeto estado</returns>
        /// <response code="200">OK. Devuelve el objeto modificado</response>
        /// <response code="400">BadRequest.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError.</response>
        [HttpPut]
        public async Task<IHttpActionResult> Put(StateDTO stateDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (stateDTO.StateID != id)
                return BadRequest("Debe ingresar el campo StateID");

            var flag = await stateService.GetById(id);

            if (flag == null)
                return NotFound();
            try
            {
                var state = mapper.Map<State>(stateDTO);
                state = await stateService.Update(state);
                return Ok(state);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Elimina un objeto estado por su Id
        /// </summary>
        /// <param name="id">Id del objeto</param>
        /// <returns>Ok</returns>
        /// <response code="200">OK. Objeto eliminado</response>
        /// <response code="500">InternalServerError.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await stateService.GetById(id);
            if (flag == null)
                return NotFound();
            try
            {
                if (!await stateService.DeleteCheckOnEntity(id))
                    await stateService.Delete(id);
                else
                    throw new Exception("ForeignKeys");
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
