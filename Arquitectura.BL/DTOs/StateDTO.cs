using System.ComponentModel.DataAnnotations;
namespace Arquitectura.BL.DTOs
{
    public class StateDTO
    {
        [Required(ErrorMessage = "El campo State ID es requerido")]
        public int? StateID { get; set; }
        [Required(ErrorMessage = "El campo Descriptions es requerido")]
        [StringLength(50)]
        public string Descriptions { get; set; }
    }
}
