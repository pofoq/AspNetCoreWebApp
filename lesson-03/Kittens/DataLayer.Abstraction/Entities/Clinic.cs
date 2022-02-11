
using System.Collections.Generic;

namespace DataLayer.Abstraction.Entities
{
    public class Clinic
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Kitten> Kittens { get; set; } = new List<Kitten>();
    }
}
