using System;

namespace ProjectX.Models.Models
{
    public class Account
    {
        public Guid EmployeeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual Employee Employee { get; set; }
    }
}