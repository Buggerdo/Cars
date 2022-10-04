using System;
using System.Collections.Generic;

namespace Cars.Models
{
    public partial class Car
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public string Vin { get; set; } = null!;
        public string Horsepower { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int? MakeId { get; set; }

        public virtual Manufacture? Make { get; set; }
    }
}
