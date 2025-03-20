using Jose.Plugin.Widgets.CustomCarousel.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Jose.Plugin.Widgets.CustomCarousel.Components;

public class CustomCarouselViewComponent : NopViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
    {
        var model = new CarouselImageModel();
        return View("~/Plugins/Widgets.CustomCarousel/Views/CarouselImageSlider.cshtml", model);
    }
}