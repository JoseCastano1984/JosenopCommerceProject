using DocumentFormat.OpenXml.Office2010.Excel;
using Jose.Plugin.Widgets.CustomCarousel.Domain;
using Jose.Plugin.Widgets.CustomCarousel.Factories;
using Jose.Plugin.Widgets.CustomCarousel.Models;
using Jose.Plugin.Widgets.CustomCarousel.Services;
using Microsoft.AspNetCore.Mvc;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Models.Extensions;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;

namespace Jose.Plugin.Widgets.CustomCarousel.Controllers;

[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]
[AutoValidateAntiforgeryToken]

public class CustomCarouselController : BasePluginController
{
    #region Fields
    
    protected readonly ICarouselModelFactory  _carouselModelFactory;
    protected readonly ICarouselService  _carouselService;
    
    #endregion
    
    #region Ctor

    public CustomCarouselController(ICarouselModelFactory carouselModelFactory, ICarouselService carouselService)
    {
        _carouselModelFactory = carouselModelFactory;
        _carouselService = carouselService;
    }
    
    #endregion
    
    [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
    public async Task<IActionResult> Configure()
    {
        var model = await _carouselModelFactory.PrepareCarouselSearchModelAsync(new  CarouselSearchModel());
        return View("~/Plugins/Widgets.CustomCarousel/Views/Configure.cshtml",  model);
    }
    
    [HttpPost]
    [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
    public async Task<IActionResult> List(CarouselSearchModel searchModel)
    {
        var model = await _carouselModelFactory.PrepareCarouselListModelAsync(searchModel);

        return Json(model);
    }
    
    [HttpPost]
    [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
    public async Task<IActionResult> Delete(int id)
    {
        var carousel = await _carouselService.GetCarouselByIdAsync(id);
        if (carousel == null)
            return RedirectToAction("Configure");

        await _carouselService.DeleteCarouselAsync(carousel);

        return new NullJsonResult();
    }

    [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
    public async Task<IActionResult> Create()
    {
        var model = new CarouselModel();
        
        return View("~/Plugins/Widgets.CustomCarousel/Views/Create.cshtml", model);
    }

    [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
    [HttpPost]
    public async Task<IActionResult> Create(CarouselModel carouselModel)
    {
        var carousel = new Carousel
        {
            CarouselName = carouselModel.CarouselName,
            StartDate = carouselModel.StartDate,
            EndDate = carouselModel.EndDate,
            Published = carouselModel.Published,
        };
        
        await _carouselService.InsertCarouselAsync(carousel);
        
        return View("~/Plugins/Widgets.CustomCarousel/Views/Create.cshtml", carouselModel);
    }
}