using Arquitectura.BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.BL.DTOs
{
    public class InputDeveloperDTO
    {
        public int? DeveloperID { get; set; }
        [Required(ErrorMessage = "El campo FirstName es requerido")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El campo LastName es requerido")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "El campo DocumentTypeID es requerido")]
        public int DocumentTypeID { get; set; }
        [Required(ErrorMessage = "El campo Identification es requerido")]
        [StringLength(10)]
        public string Identification { get; set; }
        [Required(ErrorMessage = "El campo Telephone es requerido")]
        [StringLength(10)]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "El campo Email es requerido")]
        [StringLength(50)]
        public string Email { get; set; }
    }
    public class OutputDeveloperDTO
    {
        public OutputDeveloperDTO()
        {
            DocumentType = new DocumentTypeDTO();
        }
        [Required(ErrorMessage = "El campo DocumentTypeID es requerido")]
        public int DocumentTypeID { get; set; }
        [Required(ErrorMessage = "El campo DeveloperID es requerido")]
        public int DeveloperID { get; set; }
        [Required(ErrorMessage = "El campo FirstName es requerido")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El campo LastName es requerido")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "El campo Identification es requerido")]
        [StringLength(10)]
        public string Identification { get; set; }
        [Required(ErrorMessage = "El campo Telephone es requerido")]
        [StringLength(10)]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "El campo Email es requerido")]
        [StringLength(50)]
        public string Email { get; set; }
        public DocumentTypeDTO DocumentType { get; set; }
    }
}
