using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW3.Entity
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrganizationName { get; set; }
        public DateTime CooperationStart { get; set; }
        public DateTime CooperationEnd { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
