using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam_2016.Models
{
    public class Employee
    {
        //No longer in use - check IdentityModels.cs - kept for historical purposes -- John
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int Score { get; set; }
        public string ProfilePicture { get; set; }
        public IEnumerable<Role> PastRoles { get; set; }
        public IEnumerable<Role> CurrentRoles { get; set; }
        public IEnumerable<Role> FutureRoles { get; set; }
        public IEnumerable<Achievement> AchievementsEarned { get; set; }
        public string NextYearlyInterview { get; set; }

    }
}