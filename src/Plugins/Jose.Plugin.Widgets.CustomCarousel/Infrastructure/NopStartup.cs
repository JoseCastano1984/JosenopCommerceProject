using Jose.Plugin.Widgets.CustomCarousel.Areas.Admin.Factories;
using Jose.Plugin.Widgets.CustomCarousel.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;

namespace Jose.Plugin.Widgets.CustomCarousel.Infrastructure;

public class NopStartup : INopStartup
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICarouselService, CarouselService>();
        services.AddScoped<ICarouselModelFactory, CarouselModelFactory>();
    }

    public void Configure(IApplicationBuilder application)
    {
        
    }

    public int Order => 3000;
}