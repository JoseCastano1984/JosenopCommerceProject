using Jose.Plugin.Widgets.CustomCarousel.Factories;
using Jose.Plugin.Widgets.CustomCarousel.Models;
using Jose.Plugin.Widgets.CustomCarousel.Services;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
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
}