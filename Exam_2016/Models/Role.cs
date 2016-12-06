using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Exam_2016.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<String> Curriculum { get; set; }
        public IEnumerable<Achievement> Achievements { get; set; }
    }
}