using System;
using System.Collections.Generic;

#nullable disable

namespace EfDbFirstDemo.DataModel
{
    public partial class EmpDetail
    {
        public string Id { get; set; }
        public int EmployeeId { get; set; }
        public decimal Salary { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
