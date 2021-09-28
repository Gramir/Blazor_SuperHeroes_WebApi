using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroes.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        static List<Comic> Comics = new List<Comic>
        {
            new Comic {Id=1, Name="Marvel"},
            new Comic {Id=2, Name="DC"}
        };
        
        static List<Hero> Heroes = new List<Hero>
        {
            new Hero {Id=1, Name="Spiderman", Comic= Comics[0]},
            new Hero {Id=2, Name="Batman", Comic= Comics[1]}

        };

        [HttpGet]
        public async Task <IActionResult> GetHeroes()
        {
            return Ok(Heroes);
        }

        [HttpGet("comics")]
        public async Task<IActionResult> GetComics()
        {
            return Ok(Comics);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetHero(int id)
        {
            var hero = Heroes.FirstOrDefault(c => c.Id == id);
            if (hero == null)
                return NotFound("Nothing here");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<IActionResult> PostHero(Hero hero)
        {
            hero.Id = Heroes.Max(h=> h.Id+1);
            Heroes.Add(hero);
            return Ok(Heroes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHero(Hero hero, int id)
        {
            var uhero = Heroes.FirstOrDefault(c => c.Id == id);
            if (uhero == null)
                return NotFound("Nothing here");
            var index = Heroes.IndexOf(uhero);
            Heroes[index] = hero;
            return Ok(Heroes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var hero = Heroes.FirstOrDefault(c => c.Id == id);
            if (hero == null)
                return NotFound("Nothing here");
            Heroes.Remove(hero);
            return Ok(Heroes);
        }
    }
}
