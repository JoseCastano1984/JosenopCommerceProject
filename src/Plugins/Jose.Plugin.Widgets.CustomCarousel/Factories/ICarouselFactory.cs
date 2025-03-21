using Jose.Plugin.Widgets.CustomCarousel.Models;

namespace Jose.Plugin.Widgets.CustomCarousel.Factories;

public interface ICarouselFactory
{
    Task<CarouselListModel> PrepareCarouselListModelAsync(CarouselSearchModel searchModel);
    
    Task<CarouselSearchModel> PrepareCarouselSearchModelAsync(CarouselSearchModel searchModel);
}