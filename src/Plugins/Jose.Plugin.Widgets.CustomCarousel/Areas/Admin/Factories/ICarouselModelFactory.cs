using Jose.Plugin.Widgets.CustomCarousel.Areas.Admin.Models;

namespace Jose.Plugin.Widgets.CustomCarousel.Areas.Admin.Factories;

public interface ICarouselModelFactory
{
    Task<CarouselModel>  PrepareCarouselModelAsync(int id);
    Task<CarouselModel> PrepareCarouselModelCreateAsync();
    Task<CarouselListModel> PrepareCarouselListModelAsync(CarouselSearchModel searchModel);
    Task<CarouselSearchModel> PrepareCarouselSearchModelAsync(CarouselSearchModel searchModel);
}