using System;
using System.ComponentModel.DataAnnotations;

namespace Arquitectura.BL.DTOs
{
    public class InstructorDTO
    {
        [Required(ErrorMessage = "The field Course ID is required")]
        public int ID { get; set; }
        [Required(ErrorMessage = "The field Last Name is required")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The field First MidName is required")]
        [StringLength(50)]
        public string FirstMidName { get; set; }
        [Required(ErrorMessage = "The field Hire Date is required")]
        public DateTime HireDate { get; set; }
        public string FullName
        {
            get { return string.Format("{0} {1}", LastName, FirstMidName); }
        }
    }
}
