using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.JoseCarousel.Areas.Admin.Factories;
using Nop.Plugin.Widgets.JoseCarousel.Areas.Admin.Models;
using Nop.Plugin.Widgets.JoseCarousel.Domain;
using Nop.Plugin.Widgets.JoseCarousel.Services;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Models.Extensions;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.JoseCarousel.Areas.Admin.Controllers;

public class CarouselController : BaseController
{
    private readonly ICarouselService _carouselService;
    private readonly ICarouselImageService _carouselImageService;
    private readonly ICarouselFactory _carouselFactory;
    private readonly IPermissionService _permissionService;
    private readonly IWorkContext _workContext;
    private readonly INotificationService _notificationService;
    private readonly IPictureService _pictureService;

    public CarouselController(ICarouselService carouselService, ICarouselImageService carouselImageService, 
        ICarouselFactory carouselFactory, IPermissionService permissionService, IWorkContext workContext, 
        INotificationService notificationService, IPictureService pictureService)
    {
        _carouselService = carouselService;
        _carouselImageService = carouselImageService;
        _carouselFactory = carouselFactory;
        _permissionService = permissionService;
        _workContext = workContext;
        _notificationService = notificationService;
        _pictureService = pictureService;
    }

    public async Task<IActionResult> List()
    {
        var searchModel = new CarouselSearchModel();
        searchModel.SetGridPageSize();
        return View(searchModel);
    }

    [HttpPost]
    public async Task<IActionResult> List(CarouselSearchModel searchModel)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermission.ContentManagement.TOPICS_VIEW))
            return await AccessDeniedJsonAsync();
        
        var model = await _carouselFactory.PrepareCarouselListModelAsync(searchModel);
        return Json(model);
    }
    
    public virtual async Task<IActionResult> Create()
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermission.ContentManagement.TOPICS_VIEW))
            return await AccessDeniedJsonAsync();

        var model = await _carouselFactory.PrepareCarouselModelCreateAsync();
        model.Published = true;
        
        return View(model);
    }

    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public virtual async Task<IActionResult> Create(CarouselModel model, bool continueEditing)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermission.ContentManagement.TOPICS_VIEW))
            return await AccessDeniedJsonAsync();

        if (ModelState.IsValid)
        {
            var currentCustomer = await _workContext.GetCurrentCustomerAsync();
            var carouselBanner = new Carousel()
            {
                Title = model.Title,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Deleted = false,
                Published = model.Published,
                CreatedBy = currentCustomer.Email,
                CreateDate = DateTime.Now,
                UpdatedBy = currentCustomer.Email,
                UpdatedDate = DateTime.Now
            };
            await _carouselService.InsertAsync(carouselBanner);

            if (!continueEditing)
                return RedirectToAction("List");
            
            return RedirectToAction("Edit", new { id = carouselBanner.Id });
        }
        return View(model);
    }
    public virtual async Task<IActionResult> Edit(int id)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermission.ContentManagement.TOPICS_VIEW))
            return await AccessDeniedJsonAsync();
        
        var model = await _carouselFactory.PrepareCarouselModelAsync(id);
        return View("Edit",model);
    }
    public virtual async Task<IActionResult> Edit(CarouselModel model, bool continueEditing)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermission.ContentManagement.TOPICS_VIEW))
            return await AccessDeniedJsonAsync();
        
        var carousel = await _carouselService.GetCarouselByIdAsync(model.Id);
        if(carousel == null)
            return RedirectToAction("List");

        if (ModelState.IsValid)
        {
            var currentCustomer = await _workContext.GetCurrentCustomerAsync();
            
            carousel.Title = model.Title;
            carousel.StartDate = model.StartDate;
            carousel.EndDate = model.EndDate;
            carousel.Published = model.Published;
            carousel.UpdatedBy = currentCustomer.Email;
            carousel.UpdatedDate = DateTime.Now;
            carousel.Deleted = false;
            carousel.CreatedBy = currentCustomer.Email;
            carousel.CreateDate = DateTime.Now;
            
            await _carouselService.UpdateAsync(carousel);
            
            if(!continueEditing)
                return RedirectToAction("List");
            
            return RedirectToAction("Edit", new { id = model.Id });
        }
        model = await _carouselFactory.PrepareCarouselModelAsync(model.Id);
        return View(model);
    }
    [HttpPost]
    public virtual async Task<IActionResult> Delete(int id)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermission.ContentManagement.TOPICS_VIEW))
            return await AccessDeniedJsonAsync();
        
        var carouselRecord = await _carouselService.GetCarouselByIdAsync(id);
        if(carouselRecord == null)
            return ErrorJson("Carousel record was not found");
        
        await _carouselService.DeleteAsync(carouselRecord);
        
        return RedirectToAction("List");
    }
    [HttpPost]
    public virtual async Task<bool> DeleteCarouselRecord(int id)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermission.ContentManagement.TOPICS_VIEW))
            return false;
        
        var carouselRecord = await _carouselService.GetCarouselByIdAsync(id);
        if(carouselRecord == null)
            return false;
        
        await _carouselService.DeleteAsync(carouselRecord);
        
        return true;
    }
    [HttpPost]
    public async Task<IActionResult> CarouselImagesList(CarouselImageSearchModel searchModel)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermission.ContentManagement.TOPICS_VIEW))
            return await AccessDeniedJsonAsync();

        var carouselImages = await _carouselImageService.GetCarouselImagesListAsync(searchModel.Id);
        var model = await new CarouselImageListModel().PrepareToGridAsync(searchModel, carouselImages, () =>
        {
            return carouselImages.SelectAwait(async c =>
            {
                var picture = "";
                var mobilePicture = "";
                var pictureWebP = "";
                var mobilePictureWebP = "";
                if (c.PictureId != 0)
                    picture = await _pictureService.GetPictureUrlAsync(c.PictureId);
                if (c.MobilePictureId != 0)
                    mobilePicture = await _pictureService.GetPictureUrlAsync(c.MobilePictureId);
                if (c.PictureWebPId != 0)
                    pictureWebP = await _pictureService.GetPictureUrlAsync(c.PictureWebPId);
                if (c.MobilePictureWebPId != 0)
                    mobilePictureWebP = await _pictureService.GetPictureUrlAsync(c.MobilePictureWebPId);

                var model = new CarouselImageModel()
                {
                    Id = c.Id,
                    PictureId = c.PictureId,
                    MobilePictureId = c.MobilePictureId,
                    MobilePictureWebPId = c.MobilePictureWebPId,
                    Link = c.Link,
                    DisplayOrder = c.DisplayOrder,
                    Published = c.Published,
                    IsVideo = c.IsVideo,
                    VideoUrl = c.VideoUrl,
                    VideoUrlMobile = c.VideoUrlMobile,
                    VideoText = c.VideoText,
                    VideoTextPosition = c.VideoTextPosition,
                    PictureUrl = picture,
                    MobilePictureUrl = mobilePicture,
                    PictureWebPId = c.PictureWebPId,
                    PictureUrlWebP = pictureWebP,
                    MobilePictureUrlWebP = mobilePictureWebP
                };
                return model;
            });
        });
        return Json(model);
    }
    [HttpPost]
    public async Task<IActionResult> CarouselImageInBanner(int id)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermission.ContentManagement.TOPICS_VIEW))
            return await AccessDeniedJsonAsync();

        var carousel = await _carouselImageService.GetCarouselImageByIdAsync(id)
                                ?? throw new ArgumentException("No picture found with the specified id");

        var currentCustomer = await _workContext.GetCurrentCustomerAsync();
        carousel.Deleted = true;
        carousel.UpdatedBy = currentCustomer.Email;
        carousel.UpdatedOnUtc = DateTime.UtcNow;

        await _carouselImageService.UpdateAsync(carousel);

        return new NullJsonResult();
    }
    public async Task<IActionResult> CarouselImageInBanner(CarouselImageModel model)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermission.ContentManagement.TOPICS_VIEW))
            return await AccessDeniedJsonAsync();

        if (!model.IsVideo && model.PictureId == 0)
            throw new ArgumentException();

        // var banner = await _pageBannerService.GetPageBannerByIdAsync(model.BannerId)
        //                  ?? throw new ArgumentException("No banner found with the specified id");
        //
        //
        // var picture = await _pictureService.GetPictureByIdAsync(model.PictureId)
        //               ?? throw new ArgumentException("No picture found with the specified id");
        
        var customer = await _workContext.GetCurrentCustomerAsync();

        await _carouselImageService.InsertAsync(
            new CarouselImage()
            {
                Id = model.BannerId,
                PictureId = model.PictureId,
                MobilePictureId = model.MobilePictureId,
                PictureWebPId = model.PictureWebPId,
                MobilePictureWebPId = model.MobilePictureWebPId,
                Link = model.Link,
                DisplayOrder = model.DisplayOrder,
                IsVideo = model.IsVideo,
                VideoUrl = model.VideoUrl ?? "",
                VideoUrlMobile = model.VideoUrlMobile ?? "",
                VideoText = model.VideoText ?? "",
                VideoTextPosition = model.VideoTextPosition ?? "",
                Published = true,
                Deleted = false,
                CreatedBy = customer.Email,
                CreatedOnUtc = DateTime.Now,
                UpdatedBy = customer.Email,
                UpdatedOnUtc = DateTime.Now
            });

        return Json(new { Result = true });
    }
    
    
}