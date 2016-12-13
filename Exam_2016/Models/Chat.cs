using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam_2016.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}