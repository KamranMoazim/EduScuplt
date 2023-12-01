using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class CourseMarketing
    {
        public int ID { get; set; }
        public string CourseDescription { get; set; }

        public Admin Admin { get; set; }
        public int AdminId { get; set; }
    }
}