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
    public class IndexdescriptionService : BaseService, IindexdescriptionService
    {
        private readonly IMapper _mapper;
        public IndexdescriptionService(PhotographyDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;

        }

        public Index_descriptionListViewModel getAllIndex(bool isAdmin)
        {
            List<Index_description> result = new List<Index_description>();
            if (isAdmin)
                result = this.dbContext.index_Descriptions.ToList();
            else
                result = this.dbContext.index_Descriptions.Where(x => x.IsActive == true).OrderByDescending(x => x.UpdatedOn).ToList();
            if (result == null)
                return null;
            return new Index_descriptionListViewModel { IndexDescriptions = _mapper.Map<List<Index_descriptionViewModel>>(result) };

        }
        public Index_descriptionViewModel getIndexById(bool isAdmin, int id)
        {
            Index_description result = new Index_description();
            if (isAdmin)
                result = this.dbContext.index_Descriptions.FirstOrDefault(x => x.Sno == id);
            else
                result = this.dbContext.index_Descriptions.FirstOrDefault(x => x.IsActive == true && x.Sno == id);
            if (result == null)
                return null;
            return _mapper.Map<Index_descriptionViewModel>(result);
        }
        public int? AddIndex(Index_descriptionViewModel descriptionViewModel)
        {
            Index_description model = _mapper.Map<Index_description>(descriptionViewModel);
            model.IsActive = true;
            dbContext.index_Descriptions.Add(model);
            var result = this.dbContext.SaveChanges();
            return result;
        }

        public int? DeleteIndex(int id)
        {
            var model = this.dbContext.index_Descriptions.FirstOrDefault(x => x.Sno == id);
            if (model == null)
                return null;
            dbContext.index_Descriptions.Remove(model);
            var result = this.dbContext.SaveChanges();
            return result;
        }
    }
}
