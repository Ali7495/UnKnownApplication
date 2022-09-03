using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    [Table(name: "Person", Schema = "Person")]
    public class Person : BaseModel
    {
        public Person()
        {
            Staffs = new List<Staff>();
            PersonContacts = new List<PersonContact>();
        }


        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(180)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(180)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(10)]
        public string NationalCode { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public bool? IsMarried { get; set; }
        [Required, MaxLength(30)]
        public string Gender { get; set; } = string.Empty;



        public virtual List<Staff> Staffs { get; set; }
        public virtual List<PersonContact> PersonContacts { get; set; }
    }
}
