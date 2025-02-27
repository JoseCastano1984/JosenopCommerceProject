using Nop.Plugin.Widgets.JoseCarousel.Areas.Admin.Models;
using Nop.Plugin.Widgets.JoseCarousel.Domain;

namespace Nop.Plugin.Widgets.JoseCarousel.Areas.Admin.Factories;

public interface ICarouselFactory
{
    Task<CarouselListModel> PrepareCarouselListModelAsync(CarouselSearchModel searchModel);
    
    Task<CarouselModel> PrepareCarouselModelAsync(int Id);
    
    Task<CarouselModel> PrepareCarouselModelCreateAsync();
}