using Jose.Plugin.Widgets.CustomCarousel.Components;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Jose.Plugin.Widgets.CustomCarousel;

public class CustomCarouselPlugin : BasePlugin, IWidgetPlugin
{
    private readonly IWebHelper _webHelper;

    public CustomCarouselPlugin(IWebHelper webHelper)
    {
        _webHelper = webHelper;
    }
    
    #region Properties
    
    public bool HideInWidgetList => false;
    

    #endregion
    
    #region Methods

    public override string GetConfigurationPageUrl()
    {
        return $"{_webHelper.GetStoreLocation()}Admin/CustomCarousel/Configure"; 
    }
    
    public Task<IList<string>> GetWidgetZonesAsync()
    {
        return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.HomepageTop });
    }
    public Type GetWidgetViewComponent(string widgetZone)
    {
        return typeof(CustomCarouselWidgetViewComponent);
    }
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
    
    #endregion
}