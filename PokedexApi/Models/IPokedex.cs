using System.Collections.Generic;

namespace PokedexApi.Models
{
    /// <summary>
    /// Basic API CRUD Interface.
    /// </summary>
    public interface IPokedex
    {
        void Add(Pokemon pokemon);
        IEnumerable<Pokemon> GetAll();
        Pokemon Find(long id);
        void Remove(long id);
        void Update(Pokemon pokemon);
    }
}
