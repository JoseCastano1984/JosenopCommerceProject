using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Jose.Plugin.Widgets.CustomCarousel.Models;

public record CarouselImageModel :  BaseNopEntityModel
{
    public int CarouselId { get; set; }
    
    [NopResourceDisplayName("Image")]
    [UIHint("Picture")]
    public int ImageId { get; set; }
    
    [NopResourceDisplayName("Mobile Image")]
    [UIHint("Picture")]
    public int MobileImageId { get; set; }
    
    public string? Link { get; set; }
    public int DisplayOrder { get; set; }
    public bool Published { get; set; }
}