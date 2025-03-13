using Nop.Services.Cms;
using Nop.Services.Plugins;

namespace Jose.Plugin.Widgets.CustomCarousel;

public class CustomCarouselPlugin : BasePlugin
{
    
    public override async Task InstallAsync()
    {
        //Logic during installation goes here...

        await base.InstallAsync();
    }

    public override async Task UninstallAsync()
    {
        //Logic during uninstallation goes here...

        await base.UninstallAsync();
    }
}