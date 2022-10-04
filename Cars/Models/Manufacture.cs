using System;
using System.Collections.Generic;

namespace Cars.Models
{
    public partial class Manufacture
    {
        public Manufacture()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public string Company { get; set; } = null!;
        public string Country { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; set; }
    }
}
