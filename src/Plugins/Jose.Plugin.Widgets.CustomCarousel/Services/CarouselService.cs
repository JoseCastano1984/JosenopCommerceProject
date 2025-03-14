using Jose.Plugin.Widgets.CustomCarousel.Domain;
using Nop.Core;
using Nop.Data;

namespace Jose.Plugin.Widgets.CustomCarousel.Services;

public class CarouselService : ICarouselService
{
    #region Fields
    
    protected readonly IRepository<Carousel> _carouselRepository;
    
    #endregion
    
    #region Ctor

    public CarouselService(IRepository<Carousel> carouselRepository)
    {
        _carouselRepository = carouselRepository;
    }
    
    #endregion
    
    #region Methods
    
    public async Task<IPagedList<Carousel>> GetAllCarouselsAsync(int carouselId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
    {
        var carousels = await _carouselRepository.GetAllAsync(query =>
        {
            if  (carouselId > 0)
                query = query.Where(c => c.Id == carouselId || c.Id == 0);
            query = query.OrderBy(c => c.Id).ThenBy(c => c.CarouselName);

            return query;
        });
        
        return new PagedList<Carousel>(carousels, pageIndex, pageSize);
    }

    public async Task<Carousel> GetCarouselByIdAsync(int carouselId)
    {
        return  await _carouselRepository.GetByIdAsync(carouselId);
    }

    public async Task InsertCarouselAsync(Carousel carousel)
    {
        await _carouselRepository.InsertAsync(carousel, false);
    }

    public async Task UpdateCarouselAsync(Carousel carousel)
    {
        await _carouselRepository.UpdateAsync(carousel, false);
    }

    public async Task DeleteCarouselAsync(Carousel carousel)
    {
        await  _carouselRepository.DeleteAsync(carousel, false);
    }
    
    #endregion
}