using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.Models;

namespace ViewModels.ListModels
{
    public class CarouselListViewModel :BaseViewModel
    {
        public List<CarouselViewModel> Carousels { get; set; }
    }
}
