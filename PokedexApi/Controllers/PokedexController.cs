using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PokedexApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace PokedexApi.Controllers
{
    [Route("api/[controller]")]
    public class PokedexController : Controller
    {
        public PokedexController(IPokedex pokedex)
        {
            Pokedex = pokedex;
        }
        public IPokedex Pokedex { get; set; }

        [HttpGet]
        public IEnumerable<Pokemon> GetAll()
        {
            return Pokedex.GetAll();
        }

        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(long id)
        {
            var item = Pokedex.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pokemon pokemon)
        {
            if (pokemon == null)
            {
                return BadRequest();
            }

            Pokedex.Add(pokemon);
            return CreatedAtRoute("GetById", new { id = pokemon.Id }, pokemon);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Pokemon pokemon)
        {
            if(pokemon == null || pokemon.Id != id)
            {
                return BadRequest();
            }

            Pokemon oldPokemon = Pokedex.Find(id);
            
            if(oldPokemon == null)
            {
                return NotFound();
            }

            oldPokemon.IsCaught = pokemon.IsCaught;
            oldPokemon.Name = pokemon.Name;

            Pokedex.Update(oldPokemon);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var oldPokemon = Pokedex.Find(id);
            if(oldPokemon == null)
            {
                return NotFound();
            }

            Pokedex.Remove(id);
            return new NoContentResult();
        }

    }
}