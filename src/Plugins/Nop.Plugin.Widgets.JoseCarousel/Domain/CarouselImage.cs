using Nop.Core;

namespace Nop.Plugin.Widgets.JoseCarousel.Domain;

public class CarouselImage : BaseEntity
{
    
    public int PictureId { get; set; }
    public int MobilePictureId { get; set; }
    public int PictureWebPId { get; set; }
    public int MobilePictureWebPId { get; set; }
    public string Link { get; set; }
    public int DisplayOrder { get; set; }
    public bool Published { get; set; }
    public bool Deleted { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdatedOnUtc { get; set; }
    public bool IsVideo { get; set; }
    public string VideoUrl { get; set; }
    public string VideoUrlMobile { get; set; }
    public string VideoText { get; set; }
    public string VideoTextPosition { get; set; }
}