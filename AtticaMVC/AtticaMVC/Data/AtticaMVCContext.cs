using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AtticaMVC.Models;

namespace AtticaMVC.Data
{
    public class AtticaMVCContext : DbContext
    {
        public AtticaMVCContext (DbContextOptions<AtticaMVCContext> options)
            : base(options)
        {
        }

        public DbSet<AtticaMVC.Models.Artista> Artista { get; set; } = default!;
        public DbSet<AtticaMVC.Models.ObradeArte> ObradeArte { get; set; } = default!;
    }
}
