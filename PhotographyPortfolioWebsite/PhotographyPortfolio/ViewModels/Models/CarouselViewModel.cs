using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Models
{
    public  class CarouselViewModel :BaseViewModel 
    {
        public string PhotoName { get; set; }
        public int SliderNo { get; set; }
        public string ThumbnailPath { get; set; }
        public string PhotoPath { get; set; }
        public bool IsActive { get; set; }
    }
}
