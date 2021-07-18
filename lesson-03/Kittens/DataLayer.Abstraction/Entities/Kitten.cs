
using System.Collections.Generic;

namespace DataLayer.Abstraction.Entities
{
    public class Kitten
    {
        public int Id { get; set; }

        public string NickName { get; set; }

        public double Weight { get; set; }

        public string Color { get; set; }

        public string HasCirtificate { get; set; }

        public string Feed { get; set; }

        public virtual List<Clinic> Clinics { get; set; } = new List<Clinic>();
    }
}
