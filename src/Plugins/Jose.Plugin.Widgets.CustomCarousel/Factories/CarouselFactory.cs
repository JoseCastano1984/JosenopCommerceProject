using Jose.Plugin.Widgets.CustomCarousel.Models;
using Jose.Plugin.Widgets.CustomCarousel.Services;
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
}