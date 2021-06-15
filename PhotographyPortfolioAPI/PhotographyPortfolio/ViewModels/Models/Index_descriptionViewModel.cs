using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Models
{
    public class Index_descriptionViewModel :BaseViewModel
    {
        public string Headline { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string TagPercentages { get; set; }
        public bool IsActive { get; set; }
    }
}
