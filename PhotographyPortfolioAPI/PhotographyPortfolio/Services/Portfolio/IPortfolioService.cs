using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.ListModels;
using ViewModels.Models;

namespace Services
{
    public interface IPortfolioService
    {
        PortfolioListViewModel getAllPortfolio(bool isAdmin);
        PortfolioViewModel getPortfolioById(bool isAdmin, int id);
        int? AddPortfolio(PortfolioViewModel model);
        int? DeletePortfolio(int id);
    }
}
