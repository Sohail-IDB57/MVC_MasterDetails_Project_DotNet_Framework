using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject_1280293.Models
{
    public class TraineeDetail
    {
        public int TraineeDetailId {  get; set; }
        public int TraineeId { get; set; }
        public int CourseId { get; set; }
        public string Duration { get; set; }
        public decimal CourseFee { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}