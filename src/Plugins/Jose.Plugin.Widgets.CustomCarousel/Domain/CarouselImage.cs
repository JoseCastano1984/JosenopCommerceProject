using Nop.Core;

namespace Jose.Plugin.Widgets.CustomCarousel.Domain;

public class CarouselImage : BaseEntity
{
    public int CarouselId { get; set; }
    public int ImageId { get; set; }
    public int MobileImageId { get; set; }
    public string Link { get; set; }
    public int DisplayOrder { get; set; }
    public bool Published { get; set; }
    public bool Deleted { get; set; }
}