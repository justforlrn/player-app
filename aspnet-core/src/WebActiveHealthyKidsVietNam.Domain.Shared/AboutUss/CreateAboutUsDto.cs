using System;
using System.Collections.Generic;
using System.Text;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.AboutUss
{
    public class CreateAboutUsDto
    {
        public string KeyName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        /// <summary>
        /// <h5>0:Viet Nam</h5>
        /// <h5>1:English</h5>
        /// </summary>
        public LanguageType Language { get; set; }
    }
}
