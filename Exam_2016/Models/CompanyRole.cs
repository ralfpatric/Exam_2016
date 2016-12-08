using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Exam_2016.Models
{
    public class CompanyRole
    {
        public CompanyRole()
        {
            Achievements = null;
            Curriculum = null;
            Employees = null;
        }

        public int CompanyRoleId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<string> Curriculum { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }
    }
}