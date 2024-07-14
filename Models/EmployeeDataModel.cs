using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EmployeeDetailsCRUD.Models
{
    public class EmployeeDataModel
    {
       
        public int Emp_ID { get; set; }
        [Required]
        public string Emp_Code { get; set; }
        [Required]
        public string Emp_Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct Email")]
        public string Email_ID { get; set; }

        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid  phone number")]
        public string Phone_No { get; set; }
       
        public string Designation { get; set; }
      
    }
}