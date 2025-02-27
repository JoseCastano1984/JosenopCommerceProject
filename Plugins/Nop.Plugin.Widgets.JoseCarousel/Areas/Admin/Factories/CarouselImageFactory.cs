using Nop.Core.Domain.Media;
using Nop.Plugin.Widgets.JoseCarousel.Areas.Admin.Models;
using Nop.Plugin.Widgets.JoseCarousel.Services;
using Nop.Services.Media;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Plugin.Widgets.JoseCarousel.Areas.Admin.Factories;

public class CarouselImageFactory : ICarouselImageFactory
{
    
    private readonly ICarouselImageService _carouselImageService;
    private readonly IBaseAdminModelFactory _baseAdminModelFactory;
    private readonly IPictureService _pictureService;
    private readonly MediaSettings _mediaSettings;

    public CarouselImageFactory(ICarouselImageService carouselImageService,
        IBaseAdminModelFactory baseAdminModelFactory,
        IPictureService pictureService, MediaSettings mediaSettings)
    {
        _carouselImageService = carouselImageService;
        _baseAdminModelFactory = baseAdminModelFactory;
        _pictureService = pictureService;
        _mediaSettings = mediaSettings;
    }
    
    public async Task<CarouselImageListModel> PrepareCarouselImageListModelAsync(CarouselImageSearchModel searchModel)
    {
        var carouselImages = (await _carouselImageService.GetCarouselImagesListAsync(searchModel.Id)).ToPagedList(searchModel);
    }

    public Task<CarouselImageModel> PrepareCarouselImageModelAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<CarouselImageModel> PrepareCarouselImageModelCreateAsync()
    {
        throw new NotImplementedException();
    }
}