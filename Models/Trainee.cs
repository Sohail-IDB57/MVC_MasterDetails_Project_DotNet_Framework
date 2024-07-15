using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject_1280293.Models
{
    public class Trainee
    {
        [Key] 
        public int TraineeId { get; set; }

        [Required(ErrorMessage = "Name is Required!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string TraineeName { get; set; }

        [Required(ErrorMessage = "Name is Required!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters.")]
        public string Address { get; set; }
        public string Email { get; set; }
        public string Image {  get; set; }

        public virtual ICollection<TraineeDetail> TraineeDetails { get; set; }
    }
}