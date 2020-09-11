using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDF_GENERATOR.Models
{
    public class Home
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Paste URL")]
        [Display(Name ="PASTE AN WEBSITE URL")]
        public string URL { get; set; }
        public IFormFile File { get; set; }
        public string FileUrl { get; set; }
    }
}
