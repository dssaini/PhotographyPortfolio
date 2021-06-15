using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.Models;

namespace ViewModels.ListModels
{
    public class PortfolioListViewModel : BaseViewModel
    {
       public List<PortfolioViewModel> Portfolios { get; set; }
    }
}
