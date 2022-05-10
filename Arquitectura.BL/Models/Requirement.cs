using System;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arquitectura.BL.Models
{
    [Table("Requirement", Schema = "dbo")]
    public class Requirement
    {
        [Key]
        public int? RequirementID { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public string Reach { get; set; }
        public DateTime ApplicationDate { get; set; }
        [ForeignKey("Priority")]
        public int PriorityID { get; set; }
        [ForeignKey("Developer")]
        public int DeveloperID { get; set; }
        public int DevelopmentDays { get; set; }
        public DateTime DevelopmentDate { get; set; }
        public DateTime TestingDate { get; set; }
        public virtual Project Project { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Developer Developer { get; set; }
    }
}
