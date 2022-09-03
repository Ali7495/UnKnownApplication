using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    [Table(name: "StaffPosition", Schema ="Person")]
    public class StaffPosition : BaseModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required,ForeignKey("Staff")]
        public Guid StaffId { get; set; }

        [Required, ForeignKey("Position")]
        public Guid PositionId { get; set; }

        [Required,ForeignKey("Role")]
        public string RoleId { get; set; }



        public virtual Staff Staff { get; set; }
        public virtual Position Position { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
