using Jose.Plugin.Widgets.CustomCarousel.Domain;
using Nop.Core;

namespace Jose.Plugin.Widgets.CustomCarousel.Services;

public interface ICarouselService
{
    Task<IPagedList<Carousel>> GetAllCarouselsAsync(int pageIndex = 0, int pageSize = int.MaxValue);
    Task<Carousel> GetCarouselByIdAsync(int carouselId);
    Task InsertCarouselAsync(Carousel carousel);
    Task UpdateCarouselAsync(Carousel carousel);
    Task DeleteCarouselAsync(Carousel carousel);
}