using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AtticaAPI.Models;

namespace AtticaAPI.Data
{
    public class AtticaAPIContext : DbContext
    {
        public AtticaAPIContext (DbContextOptions<AtticaAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AtticaAPI.Models.Artista> Artista { get; set; } = default!;
        public DbSet<AtticaAPI.Models.ObradeArte> ObradeArte { get; set; } = default!;
    }
}
