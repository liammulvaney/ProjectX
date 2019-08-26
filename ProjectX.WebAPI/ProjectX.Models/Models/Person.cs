using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectX.Models.Models
{
    public class Person
    {
        
        public Guid PersonId { get; set; }
        //public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
