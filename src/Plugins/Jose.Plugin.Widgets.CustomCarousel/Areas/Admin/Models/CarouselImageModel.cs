using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Jose.Plugin.Widgets.CustomCarousel.Areas.Admin.Models;

public record CarouselImageModel : BaseNopEntityModel
{
    public int CarouselId { get; set; }
    
    [NopResourceDisplayName("Image")]
    [UIHint("Picture")]
    public int PictureId { get; set; }
    
    [NopResourceDisplayName("MobileImage")]
    [UIHint("Picture")]
    public int MobilePictureId { get; set; }
    
    public string Link { get; set; }
    
    public int DisplayOrder { get; set; }
    
    public bool Published { get; set; }
}