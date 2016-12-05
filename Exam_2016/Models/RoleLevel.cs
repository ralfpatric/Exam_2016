using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam_2016.Models
{
    public class RoleLevel
    {
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
        public string Level { get; set; }
        public int Year { get; set; }
        IEnumerable<Achievement> Achievements { get; set; }

    }
}