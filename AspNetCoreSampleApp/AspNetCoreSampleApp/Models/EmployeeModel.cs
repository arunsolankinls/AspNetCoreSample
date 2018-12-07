using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreSampleApp.Models
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {
             employeelist = new List<EmployeeModel>();
        }

        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Date Of Join")]
        public string DateOfJoin { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public long PhoneNumber { get; set; }

        [Display(Name = "Upload Image")]
        public string UploadImage { get; set; }

        List<EmployeeModel> employeelist { get; set; }
    }
}
