using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Tags
    {
        public int ID { get; set; }
        public string Tag { get; set; }

        public List<Course> Courses { get; set; }
    }
}