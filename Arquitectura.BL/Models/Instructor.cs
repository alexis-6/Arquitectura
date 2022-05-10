using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Arquitectura.BL.Models
{
    [Table("Instructor", Schema = "dbo")]
    public class Instructor
    {
        [Key]
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime HireDate { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructor { get; set; } //Indica que puede estar muchas veces en la tabla CourseInstructor
    }
}
