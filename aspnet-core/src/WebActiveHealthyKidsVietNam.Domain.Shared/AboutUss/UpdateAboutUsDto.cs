using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.AboutUss
{
    public class UpdateAboutUsDto
    {
        [Required]
        public Guid AboutUsId { get; set; }
        public string KeyName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
