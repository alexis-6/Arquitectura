using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Arquitectura.BL.Models
{
    [Table("State", Schema = "dbo")]
    public class State
    {
        [Key]
        public int? StateID { get; set; }
        public string Descriptions { get; set; }
        public virtual ICollection<Project> Project { get; set; } //Indica que puede estar muchas veces en la tabla Project
    }
}
