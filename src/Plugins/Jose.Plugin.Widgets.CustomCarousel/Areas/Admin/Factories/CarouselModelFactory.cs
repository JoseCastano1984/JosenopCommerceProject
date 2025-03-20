using Jose.Plugin.Widgets.CustomCarousel.Areas.Admin.Models;
using Jose.Plugin.Widgets.CustomCarousel.Domain;
using Jose.Plugin.Widgets.CustomCarousel.Services;
using Nop.Web.Framework.Models.Extensions;

namespace Jose.Plugin.Widgets.CustomCarousel.Areas.Admin.Factories;

public class CarouselModelFactory :  ICarouselModelFactory
{
    #region Fields
    
    protected readonly ICarouselService _carouselService;
    
    #endregion
    
    #region Ctor

    public CarouselModelFactory(ICarouselService carouselService)
    {
        _carouselService = carouselService;
    }
    
    #endregion
    
    #region Methods

    public async Task<CarouselModel> PrepareCarouselModelAsync(int id)
    {
        var carouselModel = await _carouselService.GetCarouselByIdAsync(id);
        
        var carousel = PrepareCarouselModel(carouselModel);
        
        carousel.CarouselName = carouselModel.CarouselName;
        carousel.StartDate = carouselModel.StartDate;
        carousel.EndDate = carouselModel.EndDate;
        carousel.Published = carouselModel.Published;
        
        return carousel;
    }

    private CarouselModel PrepareCarouselModel(Carousel carousel)
    {
        CarouselModel model;
        if(carousel != null)
        {
            model = new CarouselModel
            {
                Id = carousel.Id,
                CarouselName = carousel.CarouselName,
                StartDate = carousel.StartDate,
                EndDate = carousel.EndDate,
                Published = carousel.Published,
            };
        }
        else
        {
            model = null;
        }
        return model;
    }
    
    public async Task<CarouselModel> PrepareCarouselModelCreateAsync()
    {
        CarouselModel carousel = new CarouselModel();
        carousel.StartDate = DateTime.Now;
        carousel.EndDate = DateTime.Now;
        
        return carousel;
    }
    public async Task<CarouselListModel> PrepareCarouselListModelAsync(CarouselSearchModel searchModel)
    {
        var carousels = await _carouselService.GetAllCarouselsAsync(pageIndex: searchModel.Page - 1,
            pageSize: searchModel.PageSize);
        var model = await new CarouselListModel().PrepareToGridAsync(searchModel, carousels, () =>
        {
            return carousels.SelectAwait(async c =>
            {
                return new CarouselModel()
                {
                    Id = c.Id,
                    CarouselName = c.CarouselName,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    Published = c.Published
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
    
    #endregion
}