using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstDb.DataModel
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Coffee> Stock { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
