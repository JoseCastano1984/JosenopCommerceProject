using System.ComponentModel.DataAnnotations.Schema;
using Nop.Core;

namespace Jose.Plugin.Widgets.CustomCarousel.Domain;

public class CarouselImage : BaseEntity
{
    public int CarouselId { get; set; }
    
    public int PictureId { get; set; }
    
    public int MobilePictureId { get; set; }
    
    public string Link { get; set; }
    
    public int DisplayOrder { get; set; }
    
    public bool Published { get; set; }
    
    [ForeignKey("CarouselId")]
    public Carousel Carousel { get; set; }
}