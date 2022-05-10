using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Arquitectura.BL.Models
{
    [Table("DocumentType", Schema = "dbo")]
    public class DocumentType
    {
        [Key]
        public int? DocumentTypeID { get; set; }
        public string Descriptions { get; set; }
        public virtual ICollection<Developer> Developer { get; set; } //Indica que puede estar muchas veces en la tabla Developer
        public virtual ICollection<Customer> Customer { get; set; } //Indica que puede estar muchas veces en la tabla Customer
    }
}
