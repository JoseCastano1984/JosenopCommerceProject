using Nop.Web.Framework.Models;

namespace Jose.Plugin.Widgets.CustomCarousel.Models;

public record CarouselModel : BaseNopEntityModel
{
    public string CarouselName { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public bool Published { get; set; }
}