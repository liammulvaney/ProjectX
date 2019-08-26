using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjectX.Models.Models
{
    public class Employee
    {
       
        public Guid EmployeeId { get; set; }
        public Guid PartitionId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Profile Profile { get; set; }
        //public ICollection<Email> Emails { get; set; }
        //public ICollection<Phone> ContactNumbers { get; set; }
    }
}