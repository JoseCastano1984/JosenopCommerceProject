using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.JoseCarousel.Areas.Admin.Models;

public record CarouselSearchModel : BaseSearchModel
{
    public int Id { get; set; }
}