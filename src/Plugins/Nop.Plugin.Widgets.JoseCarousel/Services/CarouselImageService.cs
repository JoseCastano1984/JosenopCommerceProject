using Nop.Core;
using Nop.Data;
using Nop.Plugin.Widgets.JoseCarousel.Domain;

namespace Nop.Plugin.Widgets.JoseCarousel.Services;

public class CarouselImageService : ICarouselImageService
{
    private readonly IRepository<CarouselImage> _carouselImageRepository;

    public CarouselImageService(IRepository<CarouselImage> carouselImageRepository)
    {
        _carouselImageRepository = carouselImageRepository;
    }
    
    public async Task<IPagedList<CarouselImage>> GetCarouselImagesListAsync(int carouselImageId)
    {
        return await _carouselImageRepository.GetAllPagedAsync(query =>
        {
            query = query.Where(x => x.Id == carouselImageId);
            query = query.Where(x => !x.Deleted);
            query = query.OrderBy(x => x.DisplayOrder);
            return query;
        });
    }

    public async Task<CarouselImage> GetCarouselImageByIdAsync(int id)
    {
        return await _carouselImageRepository.GetByIdAsync(id, cache => default);
    }

    public async Task InsertAsync(CarouselImage carouselImage)
    {
        await _carouselImageRepository.InsertAsync(carouselImage);
    }

    public async Task UpdateAsync(CarouselImage carouselImage)
    {
        await _carouselImageRepository.UpdateAsync(carouselImage);
    }
}