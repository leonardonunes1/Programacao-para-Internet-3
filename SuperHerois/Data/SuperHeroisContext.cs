using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperHerois.Models;

namespace SuperHerois.Data
{
    public class SuperHeroisContext : DbContext
    {
        public SuperHeroisContext (DbContextOptions<SuperHeroisContext> options)
            : base(options)
        {
        }

        public DbSet<SuperHerois.Models.SuperHeroi> SuperHeroi { get; set; }
    }
}
