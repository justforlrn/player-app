using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebActiveHealthyKidsVietNam.Informations;
using WebActiveHealthyKidsVietNam.Reports;
using WebActiveHealthyKidsVietNam.SlideLists;

namespace WebActiveHealthyKidsVietNam.ModuleHomes
{
    public class ModuleHomeEntity
    {
        public List<SlideList> Banners { get; set; }
        public List<SlideList> Slides { get; set; }
        public string Greeting { get; set; }
        public List<Information> Informations { get; set; }
        public List<Report> Indicators { get; set; }
    }
}
