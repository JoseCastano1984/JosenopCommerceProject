using System.ComponentModel.DataAnnotations;
using Jose.Plugin.Widgets.CustomCarousel.Domain;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Jose.Plugin.Widgets.CustomCarousel.Models;

public record CarouselModel : BaseNopEntityModel
{
    [NopResourceDisplayName("Carousel Name")]
    [Required(ErrorMessage = "Carousel Name is required")]
    public string CarouselName { get; set; }
    [Required(ErrorMessage = "Start Date is required")]
    public DateTime StartDate { get; set; }
    [Required(ErrorMessage = "End Date is required")]
    public DateTime EndDate { get; set; }
    
    public bool Published { get; set; }
    
    public IList<CarouselImage> ImagesInCarousel { get; set; }
}