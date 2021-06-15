using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.ListModels;
using ViewModels.Models;

namespace Services
{
    public interface ICarouselService
    {
        CarouselListViewModel getAllCarousel(bool isAdmin);
        CarouselViewModel getCarouselById(int id, bool isAdmin);
        int? addCarousel(CarouselViewModel carousel);
        int? deleteCarousel(int id);
    }
}
