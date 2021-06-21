using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Models
{
    public class PortfolioViewModel :BaseViewModel
    {
        public string PhotoName { get; set; }
        public string ThumbnailPath { get; set; }
        public string PhotoPath { get; set; }
        public bool IsActive { get; set; }
        public string Tags { get; set; }
    }
}
