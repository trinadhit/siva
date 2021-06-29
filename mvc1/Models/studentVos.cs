using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc.Razor;

namespace mvc1.Models
{
    public class studentVos
    {
        // Student Vos
        [Required(ErrorMessage = "Enter First Name")]
        [Display(Name = "First Name")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Min 6 Max 20")]
        public string STUDENT_FNAME { get; set; }

        [Required(ErrorMessage = "Enter Last Name")]
        [Display(Name = "Last Name")]
        public string STUDENT_LNAME { get; set; }

        [Required(ErrorMessage = "Enter Father Name")]
        [Display(Name = "Father Name")]
        public string FATHER_NAME { get; set; }

        [Required(ErrorMessage = "Enter Mobile No.")]
        [StringLength(maximumLength: 10, ErrorMessage = "Maximum 10 Number", MinimumLength = 10)]
        [Display(Name = "Mobile No.")]
        public string MOBILE_NO { get; set; }

        [Required(ErrorMessage = "Enter Class")]
        [Range(1, 10, ErrorMessage = "Class must be between 1 and 10")]
        public string CLASS { get; set; }

        [Required(ErrorMessage = "Enter Roll No.")]
        [Display(Name = "Roll No.")]
        public int ROLL_NO { get; set; }

        public string active { get; set; }

        public string created { get; set; }
        public string slno { get; set; }
    }
}