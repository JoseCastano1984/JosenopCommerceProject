using Nop.Web.Framework.Models;

namespace Jose.Plugin.Widgets.CustomCarousel.Models;

public record CarouselImageModel : BaseNopEntityModel
{
    public int CarouselId { get; set; }
    
    public int PictureId { get; set; }
    
    public int MobilePictureId { get; set; }
    
    public string Link { get; set; }
    
    public int DisplayOrder { get; set; }
    
    public bool Published { get; set; }
}