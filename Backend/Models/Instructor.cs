using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Instructor
    {
        public int ID { get; set; }
        public User User { get; set; }
        public string About { get; set; }
        public string AccountNo { get; set; }
        public string AccountDetails { get; set; }
        public double EarnedAmount { get; set; }
    }
}