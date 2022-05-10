using Arquitectura.BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.BL.DTOs
{
    public class InputProjectDTO
    {
        public int? ProjectID { get; set; }
        [Required(ErrorMessage = "El campo Names es requerido")]
        [StringLength(50)]
        public string Names { get; set; }
        [Required(ErrorMessage = "El campo CustomerID es requerido")]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "El campo StateID es requerido")]
        public int StateID { get; set; }
        [Required(ErrorMessage = "El campo StartDate es requerido")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "El campo FinishDate es requerido")]
        public DateTime FinishDate { get; set; }
        [Required(ErrorMessage = "El campo Price es requerido")]
        public double Price { get; set; }
        [Required(ErrorMessage = "El campo AmountHours es requerido")]
        public int AmountHours { get; set; }
    }
    public class OutputProjectDTO
    {
        public OutputProjectDTO()
        {
            Customer = new OutputCustomerDTO();
            State = new StateDTO();
        }
        public int? ProjectID { get; set; }
        [Required(ErrorMessage = "El campo Names es requerido")]
        [StringLength(50)]
        public string Names { get; set; }
        [Required(ErrorMessage = "El campo CustomerID es requerido")]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "El campo StateID es requerido")]
        public int StateID { get; set; }
        [Required(ErrorMessage = "El campo StartDate es requerido")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "El campo FinishDate es requerido")]
        public DateTime FinishDate { get; set; }
        [Required(ErrorMessage = "El campo Price es requerido")]
        public double Price { get; set; }
        [Required(ErrorMessage = "El campo AmountHours es requerido")]
        public int AmountHours { get; set; }
        public OutputCustomerDTO Customer { get; set; }
        public StateDTO State { get; set; }
    }
}
