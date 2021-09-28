using SuperHeroes.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SuperHeroes.Client.Services
{
    public class HeroService : IHeroService
    {
        private readonly HttpClient _httpclient;

        public List<Comic> Comics { get; set; } = new List<Comic>();
        public List<Hero> Heroes { get; set; } = new List<Hero>();
        public event Action OnChange;

        public HeroService(HttpClient httpClient)
        {
             _httpclient = httpClient;
        }


        public async Task GetHeroes()
        {
             Heroes = await _httpclient.GetFromJsonAsync<List<Hero>>("api/hero");
        }

        public async Task<Hero> GetHero(int id)
        {
            return await _httpclient.GetFromJsonAsync<Hero>($"api/hero/{id}");
        }
        
        public async Task<List<Hero>> PostHero(Hero hero)
        {
            var result = await _httpclient.PostAsJsonAsync($"api/hero", hero);
            Heroes = await result.Content.ReadFromJsonAsync<List<Hero>>();
            OnChange.Invoke();
            return Heroes;
        }

        public async Task GetComics()
        {
           Comics =  await _httpclient.GetFromJsonAsync<List<Comic>>($"api/hero/comics");
        }

        public async Task<List<Hero>> UpdateHero(Hero hero, int id)
        {
            var result = await _httpclient.PutAsJsonAsync($"api/hero/{id}", hero);
            Heroes = await result.Content.ReadFromJsonAsync<List<Hero>>();
            OnChange.Invoke();
            return Heroes;
        }

        public async Task<List<Hero>> DeleteHero(int id)
        {
            var result = await _httpclient.DeleteAsync($"api/hero/{id}");
            Heroes = await result.Content.ReadFromJsonAsync<List<Hero>>();
            OnChange.Invoke();
            return Heroes;
        }
    }
}
