using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
            StaffPositions = new List<StaffPosition>();
        }

        public virtual List<StaffPosition> StaffPositions { get; set; }
    }
}
