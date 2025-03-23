using Jose.Plugin.Widgets.CustomCarousel.Domain;
using Jose.Plugin.Widgets.CustomCarousel.Factories;
using Jose.Plugin.Widgets.CustomCarousel.Models;
using Jose.Plugin.Widgets.CustomCarousel.Services;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;

namespace Jose.Plugin.Widgets.CustomCarousel.Controllers;

[AutoValidateAntiforgeryToken]
[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]
public class CustomCarouselController : BasePluginController
{
    private readonly IPermissionService _permissionService;
    private readonly ICarouselService  _carouselService;
    private readonly ICarouselFactory  _carouselFactory;

    public CustomCarouselController(IPermissionService permissionService, ICarouselService carouselService, ICarouselFactory carouselFactory)
    {
        _permissionService = permissionService;
        _carouselService = carouselService;
        _carouselFactory = carouselFactory;
    }
    
    [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
    public async Task<IActionResult> Configure()
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermission.Configuration.MANAGE_WIDGETS))
            return AccessDeniedView();

        var model = await _carouselFactory.PrepareCarouselSearchModelAsync(new  CarouselSearchModel());
        return View("~/Plugins/Widgets.CustomCarousel/Views/Configure.cshtml", model);
    }
    [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
    public async Task<IActionResult> List(CarouselSearchModel searchModel)
    {
        var model = await _carouselFactory.PrepareCarouselListModelAsync(searchModel);

        return Json(model);
    }

    [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
    public async Task<IActionResult> Create()
    {
        var model = await  _carouselFactory.PrepareCarouselModelCreateAsync();
        model.Published = true;

        return View("~/Plugins/Widgets.CustomCarousel/Views/Create.cshtml", model);
    }

    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
    public async Task<IActionResult> Create(CarouselModel model, bool continueEditing)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermission.Configuration.MANAGE_WIDGETS))
            return AccessDeniedView();
        
        if (ModelState.IsValid)
        {
            var carousel = new Carousel
            {
                CarouselName = model.CarouselName,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Published = model.Published,
                Deleted = false,
                CreateDate = DateTime.Now
            };
            await _carouselService.InsertCarouselAsync(carousel);
            
            if (!continueEditing)
                return RedirectToAction("Configure");
            
            return RedirectToAction("Edit", new { id = carousel.Id });
        }
        return View("~/Plugins/Widgets.CustomCarousel/Views/Edit.cshtml", model);
    }
    
    [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
    public async Task<IActionResult> Edit(int carouselId)
    {
        var carousel = await _carouselService.GetCarouselByIdAsync(carouselId);
        if (carousel == null)
            return RedirectToAction("Configure");

        var model = new CarouselModel
        {
            Id = carousel.Id,
            CarouselName = carousel.CarouselName,
            StartDate = carousel.StartDate,
            EndDate = carousel.EndDate,
            Published = carousel.Published,
        };
        return View("~/Plugins/Widgets.CustomCarousel/Views/Edit.cshtml", model);
    }
    
    [HttpPost]
    [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
    public async Task<IActionResult> Edit(CarouselModel model)
    {
        if (!ModelState.IsValid)
            return await Edit(model.Id);
        
        var carousel = await _carouselService.GetCarouselByIdAsync(model.Id);
        if (carousel == null)
            return RedirectToAction("Configure");
        
        carousel.CarouselName = model.CarouselName;
        carousel.StartDate = model.StartDate;
        carousel.EndDate = model.EndDate;
        carousel.Published = model.Published;
        carousel.UpdatedDate = DateTime.Now;
        
        await _carouselService.UpdateCarouselAsync(carousel);
        
        ViewBag.RefreshPage = true;
        
        return View("~/Plugins/Widgets.CustomCarousel/Views/Edit.cshtml", model);
    }

    [HttpPost]
    [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
    public async Task<IActionResult> Delete(int carouselId)
    {
        var carousel = await _carouselService.GetCarouselByIdAsync(carouselId);
        if (carousel == null)
            return RedirectToAction("Configure");
        
        await _carouselService.DeleteCarouselAsync(carousel);

        return new NullJsonResult();
    }
}