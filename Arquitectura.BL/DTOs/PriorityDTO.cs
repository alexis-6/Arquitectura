using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.BL.DTOs
{
    public class PriorityDTO
    {
        [Required(ErrorMessage = "El campo Priority ID es requerido")]
        public int? PriorityID { get; set; }
        [Required(ErrorMessage = "El campo Descriptions es requerido")]
        [StringLength(100)]
        public string Descriptions { get; set; }
    }
}
