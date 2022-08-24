using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infra.Context
{
    public class UnKnownDbContext : IdentityDbContext
    {
        public UnKnownDbContext(DbContextOptions<UnKnownDbContext> options)
            : base(options)
        {

        }
    }
}
