using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexApi.Models
{
    /// <summary>
    /// Implements IPokedex with actual logics.
    /// </summary>
    public class Pokedex : IPokedex
    {
        private readonly PokedexContext _context;
        
        /// <summary>
        /// Creates Pokedex Context & create default pokemon.
        /// </summary>
        /// <param name="context"></param>
        public Pokedex(PokedexContext context)
        {
            _context = context;
            Add(new Pokemon {
                Id = 1,
                Name = "bulbasaur",
                Type = "grass",
                IsCaught = false,
            });
        }

        /// <summary>
        /// Adds New pokemon to the Pokedex.
        /// </summary>
        /// <param name="pokemon">New Pokemon</param>
        public void Add(Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
        }

        /// <summary>
        /// Create pokemon list from db and returns it.
        /// </summary>
        /// <returns>Current pokemon list in pokedex.</returns>
        public IEnumerable<Pokemon> GetAll()
        {
            return _context.Pokemons.ToList();
        }

        /// <summary>
        /// Finds Pokemon with id.
        /// </summary>
        /// <param name="id">Id of pokemon want to be found.</param>
        /// <returns>Pokemon Exist? pokemon : null</returns>
        public Pokemon Find(long id)
        {
            return _context.Pokemons.FirstOrDefault(pokemon => pokemon.Id == id);
        }

        /// <summary>
        /// Removes Pokemon with id.
        /// </summary>
        /// <param name="id"></param>
        public void Remove(long id)
        {
            var entity = _context.Pokemons.First(pokemon => pokemon.Id == id);
            _context.Pokemons.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Pokemon pokemon)
        {
            _context.Pokemons.Update(pokemon);
            _context.SaveChanges();   
        }



    }
}
