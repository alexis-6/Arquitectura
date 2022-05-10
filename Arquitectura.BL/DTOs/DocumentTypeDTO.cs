using System.ComponentModel.DataAnnotations;

namespace Arquitectura.BL.DTOs
{
    public class DocumentTypeDTO
    {
        [Required(ErrorMessage = "El campo DocumentTypeID es requerido")]
        public int? DocumentTypeID { get; set; }
        [Required(ErrorMessage = "El campo Descriptions es requerido")]
        [StringLength(50)]
        public string Descriptions { get; set; }
    }
}
