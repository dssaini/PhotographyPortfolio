using AutoMapper;
using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModels.Models;

namespace Services.Dashboard
{
    public class DashboardService:BaseService,IDashboardService
    {
        private readonly IMapper _Mapper;
        public DashboardService(PhotographyDbContext photgraphyDbContext,IMapper mapper):base(photgraphyDbContext)
        {
            _Mapper = mapper;
        }
       public DashboardViewModel getDashBoard(bool isAdmin)
        {
            Index_description result1 = new Index_description();
            List<Carousel> result2 = new List<Carousel>();
                result1 = this.dbContext.index_Descriptions.FirstOrDefault(x=>x.IsActive==true);
            result2 = this.dbContext.carousels.Where(x => x.IsActive == true).ToList();

            return new DashboardViewModel
            {
                activeArtist = _Mapper.Map<Index_descriptionViewModel>(result1),
                Carousels= _Mapper.Map<List<CarouselViewModel>>(result2)
            };
        }
    }
}
