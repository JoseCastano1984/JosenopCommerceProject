using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Media;
using Nop.Plugin.Widgets.JoseCarousel.Areas.Admin.Models;
using Nop.Plugin.Widgets.JoseCarousel.Domain;
using Nop.Plugin.Widgets.JoseCarousel.Services;
using Nop.Services.Media;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Plugin.Widgets.JoseCarousel.Areas.Admin.Factories;

public class CarouselFactory : ICarouselFactory
{
    
    private readonly ICarouselService _carouselService;
    private readonly IBaseAdminModelFactory _baseAdminModelFactory;

    public CarouselFactory(ICarouselService carouselService,
        IBaseAdminModelFactory baseAdminModelFactory)
    {
        _carouselService = carouselService;
        _baseAdminModelFactory = baseAdminModelFactory;
        
    }
    
    public async Task<CarouselListModel> PrepareCarouselListModelAsync(CarouselSearchModel searchModel)
    {
        var carousels = (await _carouselService.GetCarouselListAsync(searchModel.Id)).ToPagedList(searchModel);
        var model = await new CarouselListModel().PrepareToGridAsync(searchModel, carousels, () =>
        {
            return carousels.SelectAwait(async c =>
            {
                var carouselBanner = new CarouselModel();
                carouselBanner.Id = c.Id;
                carouselBanner.Title = c.Title;
                carouselBanner.StartDate = c.StartDate;
                carouselBanner.EndDate = c.EndDate;
                carouselBanner.Deleted = c.Deleted;
                carouselBanner.Published = c.Published;
                carouselBanner.CreatedBy = c.CreatedBy;
                carouselBanner.UpdatedBy = c.UpdatedBy;
                carouselBanner.UpdatedDate = c.UpdatedDate;
                return carouselBanner;
            });
        });
        return model;
    }

    public async Task<CarouselModel> PrepareCarouselModelAsync(int Id)
    {
        var carousel = await _carouselService.GetCarouselByIdAsync(Id);
        
        var carouselBanner = PrepareCarouselModel(carousel);

        return carouselBanner;
    }

    private CarouselModel PrepareCarouselModel(Carousel carousel)
    {
        CarouselModel carouselModel;
        if (carousel == null)
        {
            carouselModel = new CarouselModel
            {
                Id = carousel.Id,
                Title = carousel.Title,
                StartDate = carousel.StartDate,
                EndDate = carousel.EndDate,
                Deleted = carousel.Deleted,
                Published = carousel.Published,
                CreatedBy = carousel.CreatedBy,
                UpdatedBy = carousel.UpdatedBy,
                UpdatedDate = carousel.UpdatedDate,
            };
        }
        else
        {
            carouselModel = new CarouselModel();
        }
        return carouselModel;
    }

    public async Task<CarouselModel> PrepareCarouselModelCreateAsync()
    {
        CarouselModel carouselModel = new CarouselModel();
        carouselModel.StartDate = DateTime.Now;
        carouselModel.EndDate = DateTime.Now;

        return carouselModel;
    }
}