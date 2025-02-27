using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.JoseCarousel.Areas.Admin.Models;
using Nop.Plugin.Widgets.JoseCarousel.Services;
using Nop.Services.Media;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Controllers;

namespace Nop.Plugin.Widgets.JoseCarousel.Areas.Admin.Controllers;

public class CarouselImageController : BaseAdminController
{
    private readonly ICarouselImageService _carouselImageService;
    private readonly IPermissionService _permissionService;
    private readonly IWorkContext _workContext;
    private readonly IPictureService _pictureService;

    public CarouselImageController(ICarouselImageService carouselImageService, PermissionService permissionService,
        IWorkContext workContext, IPictureService pictureService)
    {
        _carouselImageService = carouselImageService;
        _permissionService = permissionService;
        _workContext = workContext;
        _pictureService = pictureService;
    }

    public async Task<ActionResult> List()
    {
        var searchModel = new CarouselImageSearchModel();
        searchModel.SetGridPageSize();
        return View(searchModel);
    }
}