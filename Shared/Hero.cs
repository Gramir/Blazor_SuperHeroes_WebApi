using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Shared
{
    public class Hero
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public Comic Comic { get; set; } = new Comic();

    }
}
