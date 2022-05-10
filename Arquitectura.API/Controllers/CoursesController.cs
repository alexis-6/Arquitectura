using Arquitectura.BL.Data;
using Arquitectura.BL.DTOs;
using Arquitectura.BL.Models;
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
    [RoutePrefix("api/Courses")]
    public class CoursesController : ApiController
    {
        private IMapper mapper;
        private readonly CourseService courseService = new CourseService(new CourseRepository(ArquitecturaContext.Create()));
        public CoursesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        /// <summary>
        /// Obtiene los objetos del curso
        /// </summary>
        /// <returns>Listado de objetos de cursos</returns>
        /// <response code="200">OK. Devuelve el listado de objetos solicitados</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<CourseDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var courses = await courseService.GetAll(); 
            var coursesDTO = courses.Select(x => mapper.Map<CourseDTO>(x));
            return Ok(coursesDTO);
        }
        /// <summary>
        /// Obtiene un objeto por su Id
        /// </summary>
        /// <param name="id">Id del objeto </param>
        /// <returns>Objeto curso</returns>
        /// /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// /// <response code="404">NotFound. No se ha encontrado el objeto solicitadoS</response>
        [HttpGet]
        [ResponseType(typeof(CourseDTO))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var course = await courseService.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            var courseDTO = mapper.Map<CourseDTO>(course);
            return Ok(courseDTO);
        }
        /// <summary>
        /// Crear el objeto curso
        /// </summary>
        /// <param name="courseDTO"></param>
        /// <returns>Objeto curso</returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        [HttpPost]
        public async Task<IHttpActionResult> Post(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var course = mapper.Map<Course>(courseDTO);
                course = await courseService.Insert(course);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put(CourseDTO courseDTO, int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(courseDTO.CourseID != id)
                return BadRequest();
            var flag = await courseService.GetById(id);

            if(flag == null)
                return NotFound();
            try
            {
                var course = mapper.Map<Course>(courseDTO);
                course = await courseService.Update(course);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await courseService.GetById(id);
            if (flag == null)
                return NotFound();
            try
            {
                if (!await courseService.DeleteCheckOnEntity(id))
                    await courseService.Delete(id);
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
