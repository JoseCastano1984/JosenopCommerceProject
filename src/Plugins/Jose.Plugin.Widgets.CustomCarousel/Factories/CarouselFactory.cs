using Jose.Plugin.Widgets.CustomCarousel.Domain;
using Jose.Plugin.Widgets.CustomCarousel.Models;
using Jose.Plugin.Widgets.CustomCarousel.Services;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Framework.Models.Extensions;

namespace Jose.Plugin.Widgets.CustomCarousel.Factories;

public class CarouselFactory : ICarouselFactory
{
    private readonly ICarouselService _carouselService;

    public CarouselFactory(ICarouselService carouselService)
    {
        _carouselService = carouselService;
    }

    public async Task<CarouselListModel> PrepareCarouselListModelAsync(CarouselSearchModel searchModel)
    {
        var carouselList = await _carouselService.GetAllCarouselsAsync(pageIndex:  searchModel.Page - 1, pageSize: searchModel.PageSize);
        
        var model = await new CarouselListModel().PrepareToGridAsync(searchModel, carouselList, () =>
        {
            return carouselList.SelectAwait(async c =>
            {
                return new CarouselModel
                {
                    Id = c.Id,
                    CarouselName = c.CarouselName,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    Published = c.Published,

                };
            });
        });
        return model;
    }

    public Task<CarouselSearchModel> PrepareCarouselSearchModelAsync(CarouselSearchModel searchModel)
    {
        ArgumentNullException.ThrowIfNull(searchModel);

        //prepare page parameters
        searchModel.SetGridPageSize();

        return Task.FromResult(searchModel);
    }
    public async Task<CarouselModel> PrepareCarouselModelAsync(CarouselModel model, Carousel carousel)
    {
        if (carousel != null)
        {
            if (model == null)
            {
                model = carousel.ToModel<CarouselModel>();
                
            }
        }
        
        //set default values for the new model
        if (carousel == null)
        {
            model.Published = true;
        }

        return model;

    }

    public async Task<CarouselModel> PrepareCarouselModelCreateAsync()
    {
        CarouselModel model = new CarouselModel();
        model.StartDate = DateTime.Now;
        model.EndDate = DateTime.Now;
        
        return model;
    }
}