using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeConsole.Models
{
    public class NameUrl
    {
        public List<NameUrl> Forms { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public string Url { get; set; }


    }
}
