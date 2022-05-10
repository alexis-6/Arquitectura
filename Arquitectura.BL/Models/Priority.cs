using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Arquitectura.BL.Models
{
    [Table("Priority", Schema = "dbo")]
    public class Priority
    {
        [Key]
        public int? PriorityID { get; set; }
        public string Descriptions { get; set; }
        public virtual ICollection<Requirement> Requirement { get; set; } //Indica que puede estar muchas veces en la tabla Requirement
    }
}
