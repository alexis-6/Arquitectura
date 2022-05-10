using Arquitectura.BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.BL.DTOs
{
    public class InputRequirementDTO
    {
        public int? RequirementID { get; set; }
        [Required(ErrorMessage = "El campo ProjectID es requerido")]
        public int ProjectID { get; set; }
        [Required(ErrorMessage = "El campo Reach es requerido")]
        public string Reach { get; set; }
        [Required(ErrorMessage = "El campo ApplicationDate es requerido")]
        public DateTime ApplicationDate { get; set; }
        [Required(ErrorMessage = "El campo PriorityID es requerido")]
        public int PriorityID { get; set; }
        [Required(ErrorMessage = "El campo DeveloperID es requerido")]
        public int DeveloperID { get; set; }
        [Required(ErrorMessage = "El campo DevelopmentDays es requerido")]
        public int DevelopmentDays { get; set; }
        [Required(ErrorMessage = "El campo DevelopmentDate es requerido")]
        public DateTime DevelopmentDate { get; set; }
        [Required(ErrorMessage = "El campo TestingDate es requerido")]
        public DateTime TestingDate { get; set; }
    }
    public class OutputRequirementDTO
    {
        public OutputRequirementDTO()
        {
            Project = new OutputProjectDTO();
            Priority = new PriorityDTO();
            Developer = new OutputDeveloperDTO();
        }
        public int? RequirementID { get; set; }
        [Required(ErrorMessage = "El campo ProjectID es requerido")]
        public int ProjectID { get; set; }
        [Required(ErrorMessage = "El campo Reach es requerido")]
        public string Reach { get; set; }
        [Required(ErrorMessage = "El campo ApplicationDate es requerido")]
        public DateTime ApplicationDate { get; set; }
        [Required(ErrorMessage = "El campo PriorityID es requerido")]
        public int PriorityID { get; set; }
        [Required(ErrorMessage = "El campo DeveloperID es requerido")]
        public int DeveloperID { get; set; }
        [Required(ErrorMessage = "El campo DevelopmentDays es requerido")]
        public int DevelopmentDays { get; set; }
        [Required(ErrorMessage = "El campo DevelopmentDate es requerido")]
        public DateTime DevelopmentDate { get; set; }
        [Required(ErrorMessage = "El campo TestingDate es requerido")]
        public DateTime TestingDate { get; set; }
        public OutputProjectDTO Project { get; set; }
        public PriorityDTO Priority { get; set; }
        public OutputDeveloperDTO Developer { get; set; }
    }
}
