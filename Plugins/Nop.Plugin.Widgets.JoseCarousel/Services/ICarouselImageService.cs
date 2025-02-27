using Nop.Core;
using Nop.Plugin.Widgets.JoseCarousel.Domain;

namespace Nop.Plugin.Widgets.JoseCarousel.Services;

public interface ICarouselImageService
{
    Task<IPagedList<CarouselImage>> GetCarouselImagesListAsync(int carouselImageId);
    
    Task<CarouselImage> GetCarouselImageByIdAsync(int id);

    Task InsertAsync(CarouselImage carouselImage);
    
    Task UpdateAsync(CarouselImage carouselImage);
}