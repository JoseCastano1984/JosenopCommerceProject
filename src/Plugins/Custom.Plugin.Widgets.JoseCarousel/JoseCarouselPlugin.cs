using Nop.Services.Cms;
using Nop.Services.Plugins;

namespace Custom.Plugin.Widgets.JoseCarousel;

public class JoseCarouselPlugin : BasePlugin
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