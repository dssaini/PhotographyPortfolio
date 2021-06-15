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
    public class CarouselService: BaseService,ICarouselService
    {
        private readonly IMapper _mapper;
        public CarouselService(PhotographyDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;

        }

        public CarouselListViewModel getAllCarousel(bool isAdmin)
        {
            List<Carousel> result = new List<Carousel>();
            if (isAdmin)
                result = this.dbContext.carousels.ToList();
            else
                result = this.dbContext.carousels.Where(x => x.IsActive == true).OrderByDescending(x => x.UpdatedOn).ToList();
            if (result == null)
                return null;
            return new CarouselListViewModel { Carousels = _mapper.Map<List<CarouselViewModel>>(result) };
        }
        public CarouselViewModel getCarouselById(int id, bool isAdmin)
        {
            Carousel result = new Carousel();
            if (isAdmin)
                result = this.dbContext.carousels.FirstOrDefault(x => x.Sno == id);
            else
                result = this.dbContext.carousels.FirstOrDefault(x => x.IsActive == true && x.Sno == id);
            if (result == null)
                return null;
            return _mapper.Map<CarouselViewModel>(result);
        }
        public int? addCarousel(CarouselViewModel carousel)
        {
            Carousel model = _mapper.Map<Carousel>(carousel);
            model.IsActive = true;
            dbContext.carousels.Add(model);
            var result = this.dbContext.SaveChanges();
            return result;
        }
        public int? deleteCarousel(int id)
        {
            var model = this.dbContext.carousels.FirstOrDefault(x => x.Sno == id);
            if (model == null)
                return null;
            dbContext.carousels.Remove(model);
            var result = this.dbContext.SaveChanges();
            return result;
        }
    }
}
