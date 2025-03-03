using Nop.Core;

namespace Nop.Plugin.Widgets.JoseCarousel.Domain;

public class Carousel : BaseEntity
{
    public string Title { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public bool Deleted { get; set; }
    
    public bool Published { get; set; }
    
    public string CreatedBy { get; set; }
    
    public DateTime CreateDate { get; set; }
    
    public string UpdatedBy { get; set; }
    
    public DateTime UpdatedDate { get; set; }
}