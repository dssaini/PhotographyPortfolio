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
    public class TagServices :BaseService, ItagServices
    {
        private readonly IMapper _mapper;
        public TagServices(PhotographyDbContext dbContext, IMapper mapper):base(dbContext)
        {
            _mapper = mapper;
        }
        public TagListViewModel getAllTags(bool isAdmin)
        {
            List<Tags> result = new List<Tags>();
            if (isAdmin)
                result = this.dbContext.tags.ToList();
            else
                result = this.dbContext.tags.OrderByDescending(x => x.UpdatedOn).ToList();
            if (result == null)
                return null;
            return new TagListViewModel { Tags = _mapper.Map<List<TagViewModel>>(result) };
        }

        public TagViewModel getTagsById(bool isAdmin, int id)
        {
            Tags result = new Tags();
            if (isAdmin)
                result = this.dbContext.tags.FirstOrDefault(x => x.Sno == id);
            else
                result = this.dbContext.tags.FirstOrDefault(x=> x.Sno == id);
            if (result == null)
                return null;
            return _mapper.Map<TagViewModel>(result);
        }
        public int? AddTag(TagViewModel tag)
        {
            Tags model = _mapper.Map<Tags>(tag);
            dbContext.tags.Add(model);
            var result = this.dbContext.SaveChanges();
            return result;
        }
        public int? DeleteTag(int id)
        {
            var model = this.dbContext.tags.FirstOrDefault(x => x.Sno == id);
            if (model == null)
                return null;
            dbContext.tags.Remove(model);
            var result = this.dbContext.SaveChanges();
            return result;
        }
    }
}
