using Jose.Plugin.Widgets.CustomCarousel.Models;

namespace Jose.Plugin.Widgets.CustomCarousel.Factories;

public interface ICarouselModelFactory
{
    Task<CarouselListModel> PrepareCarouselListModelAsync(CarouselSearchModel searchModel);
    
    Task<CarouselSearchModel> PrepareCarouselSearchModelAsync(CarouselSearchModel searchModel);
}