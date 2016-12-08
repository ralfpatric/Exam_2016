using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Exam_2016.Models
{
    public class Company
    {

        public int CompanyId { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<CompanyRole> Roles { get; set; }
        [Required]
        public string Name { get; set; }
        public string Logo { get; set; }
        public string NextYearlyInterview { get; set; }
        public virtual ICollection<string> Admins { get; set; } // when user creates a company he is added into this list

        //constructor
        public Company()
        {
            this.Admins = new List<string>();
            this.Employees = new List<Employee>();
            this.Roles = new List<CompanyRole>();
        }
    }
}