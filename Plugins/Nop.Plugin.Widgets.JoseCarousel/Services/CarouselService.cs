using Nop.Core;
using Nop.Data;
using Nop.Plugin.Widgets.JoseCarousel.Domain;

namespace Nop.Plugin.Widgets.JoseCarousel.Services;

public class CarouselService : ICarouselService
{
    private readonly IRepository<Carousel> _carouselRepository;

    public CarouselService(IRepository<Carousel> carouselRepository)
    {
        _carouselRepository = carouselRepository;
    }
    
    public async Task<IPagedList<Carousel>> GetCarouselListAsync(int carouselId)
    {
        return await _carouselRepository.GetAllPagedAsync(query =>
        {
            query = query.Where(x => x.Id == carouselId);
            query = query.Where(x => !x.Deleted);
            query = query.OrderByDescending(x => x.Id);
            return query;
        });
    }

    public async Task<Carousel> GetCarouselByIdAsync(int id)
    {
        return await _carouselRepository.GetByIdAsync(id, cache => default);
    }

    public async Task InsertAsync(Carousel carousel)
    {
        await _carouselRepository.InsertAsync(carousel);
    }

    public async Task UpdateAsync(Carousel carousel)
    {
        await _carouselRepository.UpdateAsync(carousel);
    }
}