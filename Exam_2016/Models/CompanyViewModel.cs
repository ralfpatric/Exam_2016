using System.Collections.Generic;

namespace Exam_2016.Models
{
    public class CompanyViewModel
    {
        public List<Company> Companies { get; set; }

        public Employee CurrentEmployee { get; set; }
    }
}