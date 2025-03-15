using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Jose.Plugin.Widgets.CustomCarousel.Models;

public record CarouselModel : BaseNopEntityModel
{
    [NopResourceDisplayName("Plugins.Widgets.CustomCarousel.Fields.CarouselName")]
    public string CarouselName { get; set; }
    [NopResourceDisplayName("Plugins.Widgets.CustomCarousel.Fields.StartDate")]
    public DateTime StartDate { get; set; }
    [NopResourceDisplayName("Plugins.Widgets.CustomCarousel.Fields.EndDate")]
    public DateTime EndDate { get; set; }
    [NopResourceDisplayName("Plugins.Widgets.CustomCarousel.Fields.Published")]
    public bool Published { get; set; }
}