using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASP_MVC_Core.Models;

namespace ASP_MVC_Core.Data
{
    public class ASP_MVC_CoreContext : DbContext
    {
        public ASP_MVC_CoreContext (DbContextOptions<ASP_MVC_CoreContext> options)
            : base(options)
        {
        }

        public DbSet<ASP_MVC_Core.Models.AzureKey> AzureKey { get; set; }
    }
}
