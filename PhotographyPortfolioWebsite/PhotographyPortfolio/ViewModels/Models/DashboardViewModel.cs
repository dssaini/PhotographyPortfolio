using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.ListModels;

namespace ViewModels.Models
{
    public class DashboardViewModel:BaseViewModel
    {
        public List<CarouselViewModel> Carousels { get; set; }
        public Index_descriptionViewModel activeArtist { get; set; }
    }
}
