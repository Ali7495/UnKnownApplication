using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    [Table(name: "Position", Schema = "Person")]
    public class Position : BaseModel
    {
        public Position()
        {
            StaffPositions = new List<StaffPosition>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(90)]
        public string Code { get; set; }

        [Required, MaxLength(180)]
        public string PositionName { get; set; } = string.Empty;



        public virtual List<StaffPosition>  StaffPositions { get; set; }

    }
}
