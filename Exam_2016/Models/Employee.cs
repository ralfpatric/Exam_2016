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
        public byte[] ProfilePicture { get; set; }
        public virtual ICollection<CompanyRole> AllRoles { get; set; }
        public virtual ICollection<CompanyRole> PastRoles { get; set; }
        public virtual ICollection<CompanyRole> CurrentRoles { get; set; }
        private List<CompanyRole> _FutureRoles;
        public virtual List<CompanyRole> FutureRoles {
            get
            {
                return this._FutureRoles;
            }
            set
            {
                int counter = value.Count();
                if(counter < 4)
                {
                    _FutureRoles = value;
                }
                else if(counter > 3)
                {
                    do
                    {
                        value.RemoveAt(0);
                        counter--;
                    }
                    while (counter > 3);

                    _FutureRoles = value;
                }
            }
        }
        public virtual ICollection<Achievement> AchievementsEarned { get; set; }
    }
}