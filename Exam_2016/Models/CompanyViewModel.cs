using System.Collections.Generic;

namespace Exam_2016.Models
{
    public class CompanyViewModel
    {
        public List<Company> Companies { get; set; }
        public Company Company { get; set; }
        public Employee CurrentEmployee { get; set; }
        public string CurrentEmployeeStringId { get; set; }
    }
}