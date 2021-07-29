using PokeConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var pokeService = new PokeAPIService();
            Console.WriteLine(pokeService.GetPokemonByName("mudkip").Id);
            Console.WriteLine(pokeService.GetItemByName("poke-ball").Cost);
            var listOfPokemon = pokeService.GetPokemon();
            foreach(var pokemon in listOfPokemon)
            {
                Console.WriteLine($"{pokemon.Id}: {pokemon.Name}");
            }
            Console.ReadLine();
        }
    }
}
