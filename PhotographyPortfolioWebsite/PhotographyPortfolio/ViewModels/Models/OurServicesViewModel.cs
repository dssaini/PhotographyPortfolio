using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Models
{
    public class OurServicesViewModel : BaseViewModel
    {
        public string Headline { get; set; }
        public string Description { get; set; }
        public string IconImagePath { get; set; }
        public bool IsActive { get; set; }
    }
}
