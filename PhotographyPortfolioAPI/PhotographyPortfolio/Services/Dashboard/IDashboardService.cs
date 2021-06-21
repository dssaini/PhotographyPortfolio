using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.Models;

namespace Services.Dashboard
{
    public interface IDashboardService
    {
        DashboardViewModel getDashBoard(bool isAdmin);
    }
}
