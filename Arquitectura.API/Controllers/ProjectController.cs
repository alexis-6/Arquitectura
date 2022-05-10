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
    [RoutePrefix("api/Project")]
    public class ProjectController : ApiController
    {
        private IMapper mapper;
        private readonly ProjectService projectService = new ProjectService(new ProjectRepository(ArquitecturaContext.Create()));
        public ProjectController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        #region GetAll
        /// <summary>
        /// Obtiene los objetos de proyecto
        /// </summary>
        /// <returns>Listado de objetos de proyectos</returns>
        /// <response code="200">OK. Devuelve el listado de objetos solicitados</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<OutputProjectDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var projects = await projectService.GetAll();
            var projectDTO = projects.Select(x => mapper.Map<OutputProjectDTO>(x));
            return Ok(projectDTO);
        }
        #endregion
        #region GetById
        /// <summary>
        /// Obtiene un objeto por su Id
        /// </summary>
        /// <param name="id">Id del objeto </param>
        /// <returns>Objeto proyecto</returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado</response>
        [HttpGet]
        [ResponseType(typeof(OutputProjectDTO))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var project = await projectService.GetById(id);
            if (project == null)
            {
                return NotFound();
            }
            var projectDTO = mapper.Map<OutputProjectDTO>(project);
            return Ok(projectDTO);
        }
        #endregion
        #region Post
        /// <summary>
        /// Crear el objeto proyecto
        /// </summary>
        /// <param name="projectDTO">Objeto</param>
        /// <returns>Objeto proyecto</returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// <response code="400">BadRequest.</response>
        /// <response code="500">InternalServerError.</response>
        [HttpPost]
        public async Task<IHttpActionResult> Post(InputProjectDTO projectDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (projectDTO.StartDate >= projectDTO.FinishDate)
            {
                return BadRequest("La fecha StartDate debe ser menor que la fecha FinishDate");
            }

            try
            {
                projectDTO.ProjectID = null;
                projectDTO.Names = projectDTO.Names.ToString().Trim();
                var project = mapper.Map<Project>(projectDTO);
                project = await projectService.Insert(project);
                return Ok(project);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion
        #region Put
        /// <summary>
        /// Actualiza el objeto proyecto
        /// </summary>
        /// <param name="projectDTO"> Objeto</param>
        /// <param name="id"> Id del objeto</param>
        /// <returns>objeto ´proyecto</returns>
        /// <response code="200">OK. Devuelve el objeto modificado</response>
        /// <response code="400">BadRequest.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError.</response>
        [HttpPut]
        public async Task<IHttpActionResult> Put(InputProjectDTO projectDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (projectDTO.ProjectID != id)
                return BadRequest("Debe ingresar el campo ProjectID");

            if (projectDTO.StartDate >= projectDTO.FinishDate)
            {
                return BadRequest("La fecha StartDate debe ser menor que la fecha FinishDate");
            }

            var flag = await projectService.GetById(id);

            if (flag == null)
                return NotFound();
            try
            {
                var project = mapper.Map<Project>(projectDTO);
                project = await projectService.Update(project);
                return Ok(project);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion
        #region Delete
        /// <summary>
        /// Elimina un objeto proyecto por su Id
        /// </summary>
        /// <param name="id">Id del objeto</param>
        /// <returns>Ok</returns>
        /// <response code="200">OK. Objeto eliminado</response>
        /// <response code="500">InternalServerError.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await projectService.GetById(id);
            if (flag == null)
                return NotFound();
            try
            {
                if (!await projectService.DeleteCheckOnEntity(id))
                    await projectService.Delete(id);
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
