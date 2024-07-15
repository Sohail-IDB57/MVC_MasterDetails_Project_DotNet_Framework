using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject_1280293.Models
{
    public class Course
    {
        [Key] 
        public int CourseId { get; set; }   
        public string CourseName { get; set; }
        public int CourseCategoryId { get; set; }
        public string Duration { get; set; }

        [Required(ErrorMessage = "Course Fee is Required!")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Course Fee  must be greater than 0.")]
        public decimal CourseFee { get; set; }

        public virtual CourseCategory CourseCategory { get; set; }

    }
}