using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    [Table(name: "Staff", Schema = "Person")]
    public class Staff : BaseModel
    {

        [Key]
        public Guid Id { get; set; }
        [Required,ForeignKey("Person")]
        public Guid PersonId { get; set; }
        public string Code { get; set; } = string.Empty;


        public virtual ApplicationUser User { get; set; }
        public virtual Person Person { get; set; }
    }
}
