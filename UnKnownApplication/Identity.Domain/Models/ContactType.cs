using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    [Table(name: "ContactType", Schema ="Contact")]
    public class ContactType : BaseModel
    {
        public ContactType()
        {
            PersonContacts = new List<PersonContact>();
        }


        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(90)]
        public string TypeName { get; set; } = String.Empty;



        public virtual List<PersonContact> PersonContacts { get; set; }
    }
}
