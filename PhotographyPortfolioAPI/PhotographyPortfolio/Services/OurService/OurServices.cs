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
    public class OurServices: BaseService, IOurServices
    {
        private readonly IMapper _mapper;
        public OurServices(PhotographyDbContext dbContext,IMapper mapper): base(dbContext)
        {
            _mapper = mapper;
        }
        public OurServicesListViewModel getAllService(bool isAdmin)
        {
            List<Service> result = new List<Service>();
            if (isAdmin)
                result = this.dbContext.services.ToList();
            else
                result = this.dbContext.services.Where(x => x.IsActive == true).OrderByDescending(x => x.UpdatedOn).ToList();
            if (result == null)
                return null;
            return new OurServicesListViewModel { OurServices = _mapper.Map<List<OurServicesViewModel>>(result) };
        }
        public OurServicesViewModel getServicesById(bool isAdmin, int id)
        {
            Service result = new Service();
            if (isAdmin)
                result = this.dbContext.services.FirstOrDefault(x => x.Sno == id);
            else
                result = this.dbContext.services.FirstOrDefault(x => x.IsActive == true && x.Sno == id);
            if (result == null)
                return null;
            return _mapper.Map<OurServicesViewModel>(result);
        }
        public int? AddServices(OurServicesViewModel servicesViewModel)
        {
            Service model = _mapper.Map<Service>(servicesViewModel);
            model.IsActive = true;
            dbContext.services.Add(model);
            var result = this.dbContext.SaveChanges();
            return result;
        }
        public int? DeleteServices(int id)
        {
            var model = this.dbContext.services.FirstOrDefault(x => x.Sno == id);
            if (model == null)
                return null;
            dbContext.services.Remove(model);
            var result = this.dbContext.SaveChanges();
            return result;
        }
    }
}
