using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstDb.DataModel
{
    public class Coffee
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string CountryOfOrgin { get; set; }
        public bool IsGround { get; set; }
        public string Name { get; set; }
    }
}
