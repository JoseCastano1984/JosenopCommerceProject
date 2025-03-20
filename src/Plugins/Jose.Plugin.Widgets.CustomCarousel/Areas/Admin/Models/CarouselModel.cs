using System.ComponentModel.DataAnnotations;
using Jose.Plugin.Widgets.CustomCarousel.Domain;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Jose.Plugin.Widgets.CustomCarousel.Areas.Admin.Models;

public record CarouselModel : BaseNopEntityModel
{
    [NopResourceDisplayName("Carousel Name")]
    [Required(ErrorMessage = "Carousel Name is required")]
    public string CarouselName { get; set; }
    [NopResourceDisplayName("Start Date")]
    public DateTime StartDate { get; set; }
    [NopResourceDisplayName("End Date")]
    public DateTime EndDate { get; set; }
    [NopResourceDisplayName("Published")]
    public bool Published { get; set; }
    public IList<CarouselImage> ImagesInCarousel { get; set; }
}