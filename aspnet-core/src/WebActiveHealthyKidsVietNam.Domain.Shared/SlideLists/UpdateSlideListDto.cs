using System;
using System.Collections.Generic;
using System.Text;

namespace WebActiveHealthyKidsVietNam.SlideLists
{
    public class UpdateSlideListDto
    {
        public Guid SlideId { get; set; }
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
    }
}
