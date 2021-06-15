using AutoMapper;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.Models;

namespace ViewModels.AttributeValidators
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CarouselViewModel, Carousel>(MemberList.None);
            CreateMap<Carousel, CarouselViewModel>(MemberList.None);

            CreateMap<AboutTheArtistViewModel, AboutTheArtist>(MemberList.None);
            CreateMap<AboutTheArtist, AboutTheArtistViewModel>(MemberList.None);

            CreateMap<Index_descriptionViewModel, Index_description>(MemberList.None);
            CreateMap<Index_description, Index_descriptionViewModel>(MemberList.None);

            CreateMap<PortfolioViewModel, Portfolio>(MemberList.None);
            CreateMap<Portfolio, PortfolioViewModel>(MemberList.None);

            CreateMap<OurServicesViewModel, Service>(MemberList.None);
            CreateMap<Service, OurServicesViewModel>(MemberList.None);

            CreateMap<TagViewModel, Tags>(MemberList.None);
            CreateMap<Tags, TagViewModel>(MemberList.None);
        }
        //CreateMap<CarouselViewModel, Carousel>();
        //CreateMap<Carousel, CarouselViewModel>();
    }
}
