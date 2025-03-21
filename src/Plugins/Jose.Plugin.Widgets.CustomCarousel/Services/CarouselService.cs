using Jose.Plugin.Widgets.CustomCarousel.Domain;
using LinqToDB.DataProvider.ClickHouse;
using Nop.Core;
using Nop.Data;

namespace Jose.Plugin.Widgets.CustomCarousel.Services;

public class CarouselService : ICarouselService
{
    private readonly IRepository<Carousel> _carouselRepository;

    public CarouselService(IRepository<Carousel> carouselRepository)
    {
        _carouselRepository = carouselRepository;
    }
    
    public async Task<IPagedList<Carousel>> GetAllCarouselsAsync(int pageIndex = 0, int pageSize = Int32.MaxValue)
    {
        var carousels = await _carouselRepository.GetAllAsync(query =>
        {
            query = query.OrderBy(c => c.CarouselName);
            
            return query;
        });

        return new PagedList<Carousel>(carousels, pageIndex, pageSize);
    }

    public async Task<Carousel> GetCarouselByIdAsync(int carouselId)
    {
        return await _carouselRepository.GetByIdAsync(carouselId);
    }

    public async Task InsertCarouselAsync(Carousel carousel)
    {
        await _carouselRepository.InsertAsync(carousel);
    }

    public async Task UpdateCarouselAsync(Carousel carousel)
    {
        await _carouselRepository.UpdateAsync(carousel);
    }

    public async Task DeleteCarouselAsync(Carousel carousel)
    {
        await  _carouselRepository.DeleteAsync(carousel);
    }
}