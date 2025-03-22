using Jose.Plugin.Widgets.CustomCarousel.Domain;
using Jose.Plugin.Widgets.CustomCarousel.Models;

namespace Jose.Plugin.Widgets.CustomCarousel.Factories;

public interface ICarouselFactory
{
    Task<CarouselListModel> PrepareCarouselListModelAsync(CarouselSearchModel searchModel);
    Task<CarouselSearchModel> PrepareCarouselSearchModelAsync(CarouselSearchModel searchModel);
    Task<CarouselModel> PrepareCarouselModelAsync(CarouselModel model, Carousel carousel);
    Task<CarouselModel> PrepareCarouselModelCreateAsync();
}