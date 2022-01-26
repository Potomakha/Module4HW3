using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW3.Entity
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public double Budget { get; set; }
        public DateTime StaredTime { get; set; }
        public List<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
