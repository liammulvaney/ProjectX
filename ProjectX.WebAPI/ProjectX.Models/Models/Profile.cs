using Newtonsoft.Json;
using System;

namespace ProjectX.Models.Models
{
    public class Profile
    {
        public Guid EmployeeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }
    }
}