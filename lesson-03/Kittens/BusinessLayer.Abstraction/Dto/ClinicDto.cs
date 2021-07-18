
using System.Collections.Generic;

namespace BusinessLayer.Abstraction.Dto
{
    public class ClinicDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<KittenDto> Kittens { get; set; } = new List<KittenDto>();
    }
}
