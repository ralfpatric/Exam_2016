using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam_2016.Models
{
    public class Achievement
    {
        public int AchievementId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Point { get; set; }

        public bool Approved { get; set; }

        public int RoleId { get; set; }
    }
}