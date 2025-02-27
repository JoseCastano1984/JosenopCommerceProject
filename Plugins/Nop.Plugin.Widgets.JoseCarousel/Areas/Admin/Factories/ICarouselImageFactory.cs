using Nop.Plugin.Widgets.JoseCarousel.Areas.Admin.Models;
using Nop.Plugin.Widgets.JoseCarousel.Domain;

namespace Nop.Plugin.Widgets.JoseCarousel.Areas.Admin.Factories;

public interface ICarouselImageFactory
{
    Task<CarouselImageListModel> PrepareCarouselImageListModelAsync(CarouselImageSearchModel searchModel);
    
    Task<CarouselImageModel> PrepareCarouselImageModelAsync(int Id);
    
    Task<CarouselImageModel> PrepareCarouselImageModelCreateAsync();
}