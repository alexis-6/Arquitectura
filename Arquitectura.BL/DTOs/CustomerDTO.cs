using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.BL.DTOs
{
    public class InputCustomerDTO
    {
        public int? CustomerID { get; set; }
        [Required(ErrorMessage = "El campo FirstName es requerido")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El campo LastName es requerido")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "El campo DocumentTypeID es requerido")]
        public int DocumentTypeID { get; set; }
        [Required(ErrorMessage = "El campo Identification es requerido")]
        [StringLength(20)]
        public string Identification { get; set; }
        [Required(ErrorMessage = "El campo Telephone es requerido")]
        [StringLength(10)]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "El campo Email es requerido")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo Direction es requerido")]
        [StringLength(50)]
        public string Direction { get; set; }

    }
    public class OutputCustomerDTO
    {
        public OutputCustomerDTO()
        {
            DocumentType = new DocumentTypeDTO();
        }
        [Required(ErrorMessage = "El campo CustomerID es requerido")]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "El campo FirstName es requerido")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El campo LastName es requerido")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "El campo DocumentTypeID es requerido")]
        public int DocumentTypeID { get; set; }
        [Required(ErrorMessage = "El campo Identification es requerido")]
        [StringLength(20)]
        public string Identification { get; set; }
        [Required(ErrorMessage = "El campo Telephone es requerido")]
        [StringLength(10)]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "El campo Email es requerido")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Direction Email es requerido")]
        [StringLength(50)]
        public string Direction { get; set; }
        public DocumentTypeDTO DocumentType { get; set; }

    }
}
