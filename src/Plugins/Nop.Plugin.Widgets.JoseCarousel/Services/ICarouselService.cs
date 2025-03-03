using Nop.Core;
using Nop.Plugin.Widgets.JoseCarousel.Domain;

namespace Nop.Plugin.Widgets.JoseCarousel.Services;

public interface ICarouselService
{
    Task<IPagedList<Carousel>> GetCarouselListAsync(int carouselId);
    Task<Carousel> GetCarouselByIdAsync(int id);
    Task InsertAsync(Carousel carousel);
    Task UpdateAsync(Carousel carousel);
    Task DeleteAsync(Carousel carousel);
}