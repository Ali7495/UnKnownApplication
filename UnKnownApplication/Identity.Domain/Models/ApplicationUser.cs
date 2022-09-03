using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required,ForeignKey("Staff")]
        public Guid StaffId { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [Required]
        public bool IsDeleted { get; set; }



        public virtual Staff Staff { get; set; }
    }
}
