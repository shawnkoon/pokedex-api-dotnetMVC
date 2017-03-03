using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexApi.Models
{
    /// <summary>
    /// Pokedex DB.
    /// </summary>
    public class PokedexContext : DbContext
    {
        public PokedexContext(DbContextOptions<PokedexContext> options)
            : base(options)
        {

        }

        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
