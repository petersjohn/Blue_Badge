using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeConsole.Models
{
    public class Pokemon
    {
        public List<NameUrl> Forms { get; set; }
        public List <PokeStat> Stats { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
