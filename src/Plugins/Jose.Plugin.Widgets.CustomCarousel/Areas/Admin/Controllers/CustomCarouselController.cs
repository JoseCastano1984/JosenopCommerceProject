using Jose.Plugin.Widgets.CustomCarousel.Areas.Admin.Factories;
using Jose.Plugin.Widgets.CustomCarousel.Areas.Admin.Models;
using Jose.Plugin.Widgets.CustomCarousel.Domain;
using Jose.Plugin.Widgets.CustomCarousel.Services;
using Microsoft.AspNetCore.Mvc;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;

namespace Jose.Plugin.Widgets.CustomCarousel.Areas.Admin.Controllers;

[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]
[AutoValidateAntiforgeryToken]

public class CustomCarouselController : BasePluginController
{
    #region Fields
    
    private readonly ICarouselModelFactory  _carouselModelFactory;
    private readonly ICarouselService  _carouselService;
    
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
    public virtual async Task<IActionResult> Create()
    {
        var model = await _carouselModelFactory.PrepareCarouselModelCreateAsync();
        
        return View(model);
    }

    [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public virtual async Task<IActionResult> Create(CarouselModel model, bool continueEditing)
    {
        if (ModelState.IsValid)
        {
            var carousel = new Carousel
            {
                CarouselName = model.CarouselName,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Published = model.Published,
            };
            await _carouselService.InsertCarouselAsync(carousel);
            
            if(!continueEditing)
                return RedirectToAction("Configure");
            
            return RedirectToAction("Edit", new { id = model.Id });
        }
        
        return View(model);
    }

    public virtual async Task<IActionResult> Edit(int id)
    {
        var model = await _carouselModelFactory.PrepareCarouselModelAsync(id);
        return View("Edit", model);
    }
}