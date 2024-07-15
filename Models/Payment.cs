using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject_1280293.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required(ErrorMessage = "Payment Date is Required!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PaymentDate { get; set; }
        public string PaymentPurpose {  get; set; }
        public string PaymentMethod { get; set; }


        [Required(ErrorMessage = "Unit Price is Required!")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit Price must be greater than 0.")]
        public int Amount { get; set; }

        public string PaymentStatus { get; set; }
    }
}