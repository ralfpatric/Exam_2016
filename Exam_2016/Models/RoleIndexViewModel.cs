using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam_2016.Models
{
    public class RoleIndexViewModel
    {
        public List<CompanyRole> CompanyRoles { get; set; }
        public Company CurrentCompany { get; set; }
        public Employee CurrentEmployee { get; set; }
    }
}