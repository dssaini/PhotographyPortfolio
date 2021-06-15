using AutoMapper;
using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModels.ListModels;
using ViewModels.Models;

namespace Services
{
    public class PortfolioServices :BaseService, IPortfolioService
    {
        private readonly IMapper _mapper;
        public PortfolioServices( PhotographyDbContext dbContext, IMapper mapper) :base(dbContext)
        {
            _mapper = mapper;
        }
        public PortfolioListViewModel getAllPortfolio(bool isAdmin)
        {
            List<Portfolio> result = new List<Portfolio>();
            if (isAdmin)
                result = this.dbContext.portfolios.ToList();
            else
                result = this.dbContext.portfolios.Where(x => x.IsActive == true).OrderByDescending(x => x.UpdatedOn).ToList();
            if (result == null)
                return null;
            return new PortfolioListViewModel { Portfolios = _mapper.Map<List<PortfolioViewModel>>(result) };
        }
        public PortfolioViewModel getPortfolioById(bool isAdmin, int id)
        {
            Portfolio result = new Portfolio();
            if (isAdmin)
                result = this.dbContext.portfolios.FirstOrDefault(x => x.Sno == id);
            else
                result = this.dbContext.portfolios.FirstOrDefault(x => x.IsActive == true && x.Sno == id);
            if (result == null)
                return null;
            return _mapper.Map<PortfolioViewModel>(result);
        }
        public int? AddPortfolio(PortfolioViewModel PortfolioViewModel)
        {
            Portfolio model = _mapper.Map<Portfolio>(PortfolioViewModel);
            model.IsActive = true;
            dbContext.portfolios.Add(model);
            var result = this.dbContext.SaveChanges();
            return result;
        }
        public int? DeletePortfolio(int id)
        {
            var model = this.dbContext.portfolios.FirstOrDefault(x => x.Sno == id);
            if (model == null)
                return null;
            dbContext.portfolios.Remove(model);
            var result = this.dbContext.SaveChanges();
            return result;
        }
    }
}
