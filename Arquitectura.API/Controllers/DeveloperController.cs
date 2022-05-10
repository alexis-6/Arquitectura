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
    [RoutePrefix("api/Developer")]
    public class DeveloperController : ApiController
    {
        int ContieneLetras;
        bool resultIdentificacion;
        string _identificacion;
        string _email;
        bool resultTelephone;
        string _telephone;
        string[] splitEmail = null;
        private IMapper mapper;
        private readonly DeveloperService developerService = new DeveloperService(new DeveloperRepository(ArquitecturaContext.Create()));
        public DeveloperController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        #region GetAll
        /// <summary>
        /// Obtiene los objetos de desarrollador
        /// </summary>
        /// <returns>Listado de objetos de desarrolladores</returns>
        /// <response code="200">OK. Devuelve el listado de objetos solicitados</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<OutputDeveloperDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var developers = await developerService.GetAll();
            var developerDTO = developers.Select(x => mapper.Map<OutputDeveloperDTO>(x));
            return Ok(developerDTO);
        }
        #endregion
        #region GetById
        /// <summary>
        /// Obtiene un objeto por su Id
        /// </summary>
        /// <param name="id">Id del objeto </param>
        /// <returns>Objeto desarrollador</returns>
        /// /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// /// <response code="404">NotFound. No se ha encontrado el objeto solicitado</response>
        [HttpGet]
        [ResponseType(typeof(OutputDeveloperDTO))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var developer = await developerService.GetById(id);
            if (developer == null)
            {
                return NotFound();
            }
            var developerDTO = mapper.Map<OutputDeveloperDTO>(developer);
            return Ok(developerDTO);
        }
        #endregion
        #region Post
        /// <summary>
        /// Crea el objeto desarrollador
        /// </summary>
        /// <param name="developerDTO">Objeto</param>
        /// <returns>Objeto desarrollador</returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// <response code="400">BadRequest.</response>
        /// <response code="500">InternalServerError.</response>
        [HttpPost]
        public async Task<IHttpActionResult> Post(InputDeveloperDTO developerDTO)
        {
            ContieneLetras = 0;
            resultIdentificacion = false;
            resultTelephone = false;
            _identificacion = developerDTO.Identification.ToString();
            _telephone = developerDTO.Telephone.ToString();
            _email = developerDTO.Email.ToLower().ToString();
            splitEmail = _email.Split('@');

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            resultIdentificacion = int.TryParse(_identificacion, out ContieneLetras);
            if (resultIdentificacion == false)
            {
                return BadRequest("La identificacion ingresada no es válida");
            }

            resultTelephone = int.TryParse(_telephone, out ContieneLetras);
            if (resultTelephone == false)
            {
                return BadRequest("El telefono ingresado no es válido");
            }

            if (splitEmail.Count() != 2)
            {
                return BadRequest("El email ingresado no contiene el caracter '@'");
            }

            if (!(DOMINIO.listaDomninios.Any(x => x.Equals(splitEmail[1].ToString()))) || (!_email.Contains("@")))
            {
                return BadRequest("El email ingresado no contiene un dominio de correo electronico válido");
            }

            try
            {
                developerDTO.DeveloperID = null;
                developerDTO.FirstName = developerDTO.FirstName.Trim();
                developerDTO.LastName = developerDTO.LastName.Trim();
                developerDTO.Identification = developerDTO.Identification.Trim();
                developerDTO.Telephone = developerDTO.Telephone.Trim();
                developerDTO.Email = developerDTO.Email.ToString().ToLower().Trim();
                var developer = mapper.Map<Developer>(developerDTO);
                developer = await developerService.Insert(developer);
                return Ok(developer);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion
        /// <summary>
        /// Actualiza el objeto desarrollador
        /// </summary>
        /// <param name="developerDTO">Objeto</param>
        /// <param name="id">Id del objeto</param>
        /// <returns>objeto desarrollador</returns>
        /// <response code="200">OK. Devuelve el objeto modificado</response>
        /// <response code="400">BadRequest.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError.</response>
        [HttpPut]
        public async Task<IHttpActionResult> Put(InputDeveloperDTO developerDTO, int id)
        {
            ContieneLetras = 0;
            resultIdentificacion = false;
            resultTelephone = false;
            _identificacion = developerDTO.Identification.ToString();
            _telephone = developerDTO.Telephone.ToString();
            _email = developerDTO.Email.ToString().ToLower().Trim();
            splitEmail = _email.Split('@');

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (developerDTO.DeveloperID != id)
                return BadRequest("Debe ingresar el campo DeveloperID");
            var flag = await developerService.GetById(id);

            if (flag == null)
                return NotFound();

            resultIdentificacion = int.TryParse(_identificacion, out ContieneLetras);
            if (resultIdentificacion == false)
            {
                return BadRequest("La identificacion ingresada no es válida");
            }

            resultTelephone = int.TryParse(_telephone, out ContieneLetras);
            if (resultTelephone == false)
            {
                return BadRequest("El telefono ingresado no es válido");
            }

            if (splitEmail.Count() != 2)
            {
                return BadRequest("El email ingresado no contiene el caracter '@'");
            }

            if (!(DOMINIO.listaDomninios.Any(x => x.Equals(splitEmail[1].ToString()))) || (!_email.Contains("@")))
            {
                return BadRequest("El email ingresado no contiene un dominio de correo electronico válido");
            }
            try
            {
                developerDTO.FirstName = developerDTO.FirstName.Trim();
                developerDTO.LastName = developerDTO.LastName.Trim();
                developerDTO.Identification = developerDTO.Identification.Trim();
                developerDTO.Telephone = developerDTO.Telephone.Trim();
                developerDTO.Email = developerDTO.Email.ToString().ToLower().Trim();
                var developer = mapper.Map<Developer>(developerDTO);
                developer = await developerService.Update(developer);
                return Ok(developer);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Elimina un objeto desarrollador por su Id
        /// </summary>
        /// <param name="id">Id del objeto</param>
        /// <returns>Ok</returns>
        /// <response code="200">OK. Objeto eliminado</response>
        /// <response code="500">InternalServerError.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await developerService.GetById(id);
            if (flag == null)
                return NotFound();
            try
            {
                if (!await developerService.DeleteCheckOnEntity(id))
                    await developerService.Delete(id);
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
