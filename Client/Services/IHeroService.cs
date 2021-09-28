using SuperHeroes.Client.Pages;
using SuperHeroes.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SuperHeroes.Client.Services
{
    public interface IHeroService
    {
        event Action OnChange;
        public Task GetHeroes();
        public Task GetComics();
        public List<Comic> Comics { get; set; }
        public List<Hero> Heroes { get; set; }
        public Task<Hero> GetHero(int id);

        public Task<List<Hero>> PostHero(Hero hero);
        public Task<List<Hero>> UpdateHero(Hero hero, int id);
        public Task<List<Hero>> DeleteHero(int id);
    }
}
