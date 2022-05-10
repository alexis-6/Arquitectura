using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arquitectura.BL.Models
{
    [Table("Project", Schema = "dbo")]
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        public string Names { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        [ForeignKey("State")]
        public int StateID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public double Price { get; set; }
        public int AmountHours { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Requirement> Requirement { get; set; } //Indica que puede estar muchas veces en la tabla Requirement

    }
}
