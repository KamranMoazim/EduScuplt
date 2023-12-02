using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class CourseMarketing
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Course Description is required.")]
        [StringLength(250, ErrorMessage = "Course Description must be at most 250 characters.")]
        public string CourseDescription { get; set; }

        public Admin Admin { get; set; }
        public int AdminId { get; set; }
    }
}