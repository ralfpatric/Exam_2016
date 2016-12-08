using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam_2016.Models
{
    public class Employee : ApplicationUser
    {
        public int EmployeeId { get; set; } // this is being ignored atm
        public int? CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int Score { get; set; }
        public string ProfilePicture { get; set; }
        public IEnumerable<CompanyRole> PastRoles { get; set; }
        public IEnumerable<CompanyRole> CurrentRoles { get; set; }
        public IEnumerable<CompanyRole> FutureRoles { get; set; }
        public IEnumerable<Achievement> AchievementsEarned { get; set; }
    }
}