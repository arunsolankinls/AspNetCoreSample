using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreSampleApp.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public string UploadImage { get; set; }
    }
}
