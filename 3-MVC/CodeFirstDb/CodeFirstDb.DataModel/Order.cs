using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstDb.DataModel
{
    public class Order
    {
        public int Id { get; set; }
        public Coffee Coffee { get; set; }
        public Store Store { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}
