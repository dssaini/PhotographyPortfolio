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
    public class ArtistService:BaseService, IArtistServices
    {
        private readonly IMapper _mapper;
        public ArtistService(PhotographyDbContext DbContext, IMapper mapper):base(DbContext)
        {
            _mapper = mapper;
        }
        public AboutTheArtistListViewModel getAllArtist(bool isAdmin)
        {
            List<AboutTheArtist> result = new List<AboutTheArtist>();
            if (isAdmin)
                result = this.dbContext.aboutTheArtists.ToList();
            else
                result = this.dbContext.aboutTheArtists.OrderByDescending(x => x.UpdatedOn).ToList();
            if (result == null)
                return null;
            return new AboutTheArtistListViewModel { AboutTheArtists = _mapper.Map<List<AboutTheArtistViewModel>>(result) };
        }
        public AboutTheArtistViewModel getArtistById(bool isAdmin, int id)
        {
            AboutTheArtist result = new AboutTheArtist();
            if (isAdmin)
                result = this.dbContext.aboutTheArtists.FirstOrDefault(x => x.Sno == id);
            else
                result = this.dbContext.aboutTheArtists.FirstOrDefault(x => x.Sno == id);
            if (result == null)
                return null;
            return _mapper.Map<AboutTheArtistViewModel>(result);
        }
        public int? AddArtist(AboutTheArtistViewModel artist)
        {
            AboutTheArtist model = _mapper.Map<AboutTheArtist>(artist);
            dbContext.aboutTheArtists.Add(model);
            var result = this.dbContext.SaveChanges();
            return result;
        }
        public int? DeleteArtist(int id)
        {
            var model = this.dbContext.aboutTheArtists.FirstOrDefault(x => x.Sno == id);
            if (model == null)
                return null;
            dbContext.aboutTheArtists.Remove(model);
            var result = this.dbContext.SaveChanges();
            return result;
        }
    }
}
