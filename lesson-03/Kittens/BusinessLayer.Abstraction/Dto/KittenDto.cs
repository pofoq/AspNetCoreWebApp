
using System.Collections.Generic;

namespace BusinessLayer.Abstraction.Dto
{
    public class KittenDto
    {
        public int Id { get; set; }

        public string NickName { get; set; }

        public double Weight { get; set; }

        public string Color { get; set; }

        public string HasCirtificate { get; set; }

        public string Feed { get; set; }

        public virtual List<ClinicDto> Clinics { get; set; } = new List<ClinicDto>();
    }
}
