using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    [Table(name: "PersonContact", Schema ="Contact")]
    public class PersonContact : BaseModel
    {

        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Person"),Required]
        public Guid PersonId { get; set; }
        [ForeignKey("ContactType"),Required]
        public Guid ContactTypeId { get; set; }
        [Required]
        [MaxLength(300)]
        public string Key { get; set; } = String.Empty;
        [Required]
        [MaxLength(300)]
        public string Value { get; set; } = String.Empty;



        public virtual ContactType ContactType { get; set; }
        public virtual Person Person { get; set; }
    }
}
