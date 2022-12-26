using System;
using System.Collections.Generic;
using System.Text;
using WebActiveHealthyKidsVietNam.Informations;
using WebActiveHealthyKidsVietNam.Reports;
using WebActiveHealthyKidsVietNam.SlideLists;

namespace WebActiveHealthyKidsVietNam.ModuleHomes
{
    public class GetHomePageDto
    {
        public List<SlideListDto> Banners { get; set; }
        public List<SlideListDto> Slides { get; set; }
        public string Greeting { get; set; }
        public List<InformationDto> Informations { get; set; }
        public List<ReportDto> Indicators { get; set; }
    }
}
