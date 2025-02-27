using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.JoseCarousel.Areas.Admin.Models;

public record CarouselImageModel : BaseNopEntityModel
{
    public int BannerId { get; set; }
        
    [NopResourceDisplayName("Image")]
    [UIHint("Picture")]
    public int PictureId { get; set; }
        
    [NopResourceDisplayName("MobileImage")]
    [UIHint("Picture")]
    public int MobilePictureId { get; set; }
    public string? PictureUrl { get; set; }
    public string? MobilePictureUrl { get; set; }
        
    [NopResourceDisplayName("ImageWebP")]
    [UIHint("Picture")]
    public int PictureWebPId { get; set; }
        
    [NopResourceDisplayName("MobileImageWebP")]
    [UIHint("Picture")]
    public int MobilePictureWebPId { get; set; }
    public string? PictureUrlWebP { get; set; }
    public string? MobilePictureUrlWebP { get; set; }
    public string? Link { get; set; }
    public int DisplayOrder { get; set; }
    public bool Published { get; set; }
        
    public bool IsVideo { get; set; }
    public string? VideoUrl { get; set; }
    public string? VideoUrlMobile { get; set; }
    public string? VideoText { get; set; }
    public string? VideoTextPosition { get; set; }
}