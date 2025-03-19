using Nop.Core;

namespace Jose.Plugin.Widgets.CustomCarousel.Domain;

public class Carousel : BaseEntity
{
    public string CarouselName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool Published { get; set; }
    
    public CarouselImage CarouselImagesInCarousel { get; set; }
    
}