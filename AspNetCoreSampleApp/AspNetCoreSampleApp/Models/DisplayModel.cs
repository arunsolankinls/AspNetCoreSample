using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace AspNetCoreSampleApp.Models
{
    public class DisplayModel
    {
        //public int Id { get; set; }
        //public string UploadFilePath { get; set; }

        //public IFormFile myfile { get; set; }

        [Required]
        [Display(Name = "Title")]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Public Schedule")]
        public IFormFile UploadPublicSchedule { get; set; }

        [Required]
        [Display(Name = "Private Schedule")]
        public IFormFile UploadPrivateSchedule { get; set; }
    }
}
