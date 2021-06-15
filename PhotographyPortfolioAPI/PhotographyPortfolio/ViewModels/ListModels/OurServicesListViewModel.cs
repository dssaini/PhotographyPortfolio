using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.Models;

namespace ViewModels.ListModels
{
    public class OurServicesListViewModel :BaseViewModel
    {
        public List<OurServicesViewModel> OurServices { get; set; }
    }
}
