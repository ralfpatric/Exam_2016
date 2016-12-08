using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam_2016.Models
{
    public class Employee : ApplicationUser
    {
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int Score { get; set; }
        public string ProfilePicture { get; set; }
        public virtual ICollection<CompanyRole> PastRoles { get; set; }
        public virtual ICollection<CompanyRole> CurrentRoles { get; set; }
        public virtual ICollection<CompanyRole> FutureRoles { get; set; }
        public virtual ICollection<Achievement> AchievementsEarned { get; set; }
    }
}