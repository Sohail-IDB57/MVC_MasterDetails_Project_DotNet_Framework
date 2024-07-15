using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject_1280293.Models.ViewModel
{
    public class TraineeViewModel
    {
        public int TraineeDetailId { get; set; }
        public int TraineeId { get; set; }
        public int CourseId { get; set; }
        public string Duration { get; set; }
        public decimal CourseFee { get; set; }

        //
        public string TraineeName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Image { get; set; }

        public bool Terms { get; set; }
    }
}