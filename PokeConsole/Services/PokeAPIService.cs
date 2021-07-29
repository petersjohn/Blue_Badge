using Newtonsoft.Json;
using PokeConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokeConsole.Services
{
    class PokeAPIService
    {
        public Pokemon GetPokemonByName(string name)
        {
            var http = new HttpClient();
            var pokemonResponse = http.GetAsync("https://pokeapi.co/api/v2/pokemon/" + name).Result;
            if (pokemonResponse.IsSuccessStatusCode)
            {
                var pokemon = JsonConvert.DeserializeObject<Pokemon>(pokemonResponse.Content.ReadAsStringAsync().Result);
                return pokemon;
            }

            return null;

        }

        //get an item by name


        public PokeItem GetItemByName(string name)
        {
            var http = new HttpClient();
            var itemResponse = http.GetAsync("https://pokeapi.co/api/v2/item/" + name).Result;
            if (itemResponse.IsSuccessStatusCode)
            {
                var item = JsonConvert.DeserializeObject<PokeItem>(itemResponse.Content.ReadAsStringAsync().Result);
                return item;
            }

            return null;

        }

        public IEnumerable<Pokemon> GetPokemon()
        {
            var http = new HttpClient();
            var pokemonResponse = http.GetAsync("https://pokeapi.co/api/v2/pokemon/").Result;
            if (pokemonResponse.IsSuccessStatusCode)
            {
                var pokemon = new List<Pokemon>();
                var resModel = JsonConvert.DeserializeObject<SearchResults<NameUrl>>(pokemonResponse.Content.ReadAsStringAsync().Result);
                foreach (NameUrl item in resModel.Results)
                {
                    var thisPokemonModel = http.GetAsync(item.Url).Result;
                    if (thisPokemonModel.IsSuccessStatusCode)
                    {
                        var thisPokemon = JsonConvert.DeserializeObject<Pokemon>(thisPokemonModel.Content.ReadAsStringAsync().Result);
                        pokemon.Add(thisPokemon);
                    }
                }
                return pokemon;

            }

            return null;

        }

    }
}
