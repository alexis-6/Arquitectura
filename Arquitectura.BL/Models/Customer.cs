using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Arquitectura.BL.Models
{
    [Table("Customer", Schema = "dbo")]
    public class Customer
    {
        [Key]
        public int? CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("DocumentType")]
        public int DocumentTypeID { get; set; }
        public string Identification { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Direction { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public virtual ICollection<Project> Project { get; set; } //Indica que puede estar muchas veces en la tabla Project
    }
}
