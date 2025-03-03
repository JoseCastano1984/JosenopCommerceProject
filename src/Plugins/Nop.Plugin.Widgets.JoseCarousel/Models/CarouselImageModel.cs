namespace Nop.Plugin.Widgets.JoseCarousel.Models;

public class CarouselImageModel
{
    public string PictureUrl { get; set; }
    public string MobilePictureUrl { get; set; }
    public string PictureUrlWebP { get; set; }
    public string MobilePictureUrlWebP { get; set; }
    public string Link { get; set; }
    
    public bool IsVideo { get; set; }
    public string VideoUrl { get; set; }
    public string VideoUrlMobile { get; set; }
    public string VideoText { get; set; }
    public string VideoTextPosition { get; set; }
    public int DisplayOrder { get; set; }
}