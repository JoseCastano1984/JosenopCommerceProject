using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.Widgets.JoseCarousel.Services;

namespace Nop.Plugin.Widgets.JoseCarousel.Infrastructure;

public class NopStartup : INopStartup
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICarouselService, CarouselService>();
        services.AddScoped<ICarouselImageService, CarouselImageService>();
    }

    public void Configure(IApplicationBuilder application)
    {
        
    }

    public int Order => 400;
}