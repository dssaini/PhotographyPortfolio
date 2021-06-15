using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.ListModels;
using ViewModels.Models;

namespace Services
{
    public interface IOurServices
    {
        OurServicesListViewModel getAllService(bool isAdmin);
        OurServicesViewModel getServicesById(bool isAdmin, int id);
        int? AddServices(OurServicesViewModel model);
        int? DeleteServices(int id);
    }
}
