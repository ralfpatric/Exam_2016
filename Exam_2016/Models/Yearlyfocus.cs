using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam_2016.Models
{
    public class Yearlyfocus
    {
        public int YearlyfocusId { get; set; }
        public int Year { get; set; }
        public int EmployeeId { get; set; }
        public virtual ICollection<CompanyRole> Roles { get; set; }
    }
}