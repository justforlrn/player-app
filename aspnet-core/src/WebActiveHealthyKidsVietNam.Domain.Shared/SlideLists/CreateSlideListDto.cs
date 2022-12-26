using System;
using System.Collections.Generic;
using System.Text;
using WebActiveHealthyKidsVietNam.Commons;

namespace WebActiveHealthyKidsVietNam.SlideLists
{
    public class CreateSlideListDto
    {
        public string SlideTitle { get; set; }
        public string SlideContent { get; set; }
        /// <summary>
        /// <h5>0: Banner</h5>
        /// <h5>1: Slide</h5>
        /// <h5>2: Publication</h5>
        /// <h5>3: Event</h5>
        /// </summary>
        public SlideType SlideType { get; set; }
        public string ImageUrl { get; set; }
        /// <summary>
        /// thứ tự từng hình ảnh
        /// </summary>
        public int SlideOder { get; set; }
        public Guid ModuleId { get; set; }
        public LanguageType Language { get; set; }
    }
}
