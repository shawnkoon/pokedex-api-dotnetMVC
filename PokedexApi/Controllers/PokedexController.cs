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

        [HttpGet("{id}", Name ="Do I need?")]
        public IActionResult GetById(long id)
        {
            var item = Pokedex.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}