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
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Arquitectura.API.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        int ContieneLetras;
        bool resultIdentificacion;
        string _identificacion;
        string _email;
        bool resultTelephone;
        string _telephone;
        string[] splitEmail = null;
        private IMapper mapper;
        private readonly CustomerService customerService = new CustomerService(new CustomerRepository(ArquitecturaContext.Create()));
        public CustomerController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        #region GetAll
        /// <summary>
        /// Obtiene los objetos de clientes
        /// </summary>
        /// <returns>Listado de objetos de clientes</returns>
        /// <response code="200">OK. Devuelve el listado de objetos solicitados</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<OutputCustomerDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var customers = await customerService.GetAll();
            var customerDTO = customers.Select(x => mapper.Map<OutputCustomerDTO>(x));
            return Ok(customerDTO);
        }
        #endregion
        #region GetById
        /// <summary>
        /// Obtiene un objeto por su Id
        /// </summary>
        /// <param name="id">Id del objeto </param>
        /// <returns>Objeto cliente</returns>
        /// /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// /// <response code="404">NotFound. No se ha encontrado el objeto solicitado</response>
        [HttpGet]
        [ResponseType(typeof(OutputCustomerDTO))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var customer = await customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerDTO = mapper.Map<OutputCustomerDTO>(customer);
            return Ok(customerDTO);
        }
        #endregion
        #region Post
        /// <summary>
        /// Crea el objeto cliente
        /// </summary>
        /// <param name="customerDTO">Objeto</param>
        /// <returns>Objeto cliente</returns>
        /// <response code="200">OK. Devuelve el objeto solicitado</response>
        /// <response code="400">BadRequest.</response>
        /// <response code="500">InternalServerError.</response>
        [HttpPost]
        public async Task<IHttpActionResult> Post(InputCustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ContieneLetras = 0;
            resultIdentificacion = false;
            resultTelephone = false;
            _identificacion = customerDTO.Identification.ToString();
            _telephone = customerDTO.Telephone.ToString();
            _email = customerDTO.Email.ToLower().ToString();
            splitEmail = _email.Split('@');
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
                customerDTO.CustomerID = null;
                customerDTO.FirstName = customerDTO.FirstName.Trim();
                customerDTO.LastName = customerDTO.LastName.Trim();
                customerDTO.Identification = customerDTO.Identification.Trim();
                customerDTO.Telephone = customerDTO.Telephone.Trim();
                customerDTO.Email = customerDTO.Email.ToString().ToLower().Trim();
                customerDTO.Direction = customerDTO.Direction.Trim();
                var customer = mapper.Map<Customer>(customerDTO);
                customer = await customerService.Insert(customer);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion
        /// <summary>
        /// Actualiza el objeto cliente
        /// </summary>
        /// <param name="customerDTO">Objeto</param>
        /// <param name="id">Id del objeto</param>
        /// <returns>objeto cliente</returns>
        /// <response code="200">OK. Devuelve el objeto modificado</response>
        /// <response code="400">BadRequest.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError.</response>
        [HttpPut]
        public async Task<IHttpActionResult> Put(InputCustomerDTO customerDTO, int id)
        {
            ContieneLetras = 0;
            resultIdentificacion = false;
            resultTelephone = false;
            _identificacion = customerDTO.Identification.ToString();
            _telephone = customerDTO.Telephone.ToString();
            _email = customerDTO.Email.ToLower().ToString().Trim();
            splitEmail = _email.Split('@');

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (customerDTO.CustomerID != id)
                return BadRequest("Debe ingresar el campo CustomerID");

            var flag = await customerService.GetById(id);

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
                customerDTO.FirstName = customerDTO.FirstName.Trim();
                customerDTO.LastName = customerDTO.LastName.Trim();
                customerDTO.Identification = customerDTO.Identification.Trim();
                customerDTO.Telephone = customerDTO.Telephone.Trim();
                customerDTO.Email = customerDTO.Email.ToString().ToLower().Trim();
                customerDTO.Direction =  customerDTO.Direction.Trim();
                var customer = mapper.Map<Customer>(customerDTO);
                customer = await customerService.Update(customer);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Elimina un objeto cliente por su Id
        /// </summary>
        /// <param name="id">Id del objeto</param>
        /// <returns>Ok</returns>
        /// <response code="200">OK. Objeto eliminado</response>
        /// <response code="500">InternalServerError.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await customerService.GetById(id);
            if (flag == null)
                return NotFound();
            try
            {
                if (!await customerService.DeleteCheckOnEntity(id))
                    await customerService.Delete(id);
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
