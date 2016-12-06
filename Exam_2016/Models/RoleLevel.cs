using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Exam_2016.Models
{
    public class RoleLevel
    {
        [Key]
        [Column(Order = 1)]
        public int EmployeeId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int RoleId { get; set; }
        public string Level { get; set; }
        public int Year { get; set; }
        public IEnumerable<Achievement> Achievements { get; set; }
    }
}