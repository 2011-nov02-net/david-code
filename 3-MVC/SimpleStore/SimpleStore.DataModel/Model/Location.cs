using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.DataModel.Model
{
    public class Location
    {
        public int Id { get; set; } // will become PK by convention
        public string Name { get; set; }
        public int Stock { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
