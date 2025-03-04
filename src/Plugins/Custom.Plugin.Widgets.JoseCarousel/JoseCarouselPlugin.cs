using Custom.Plugin.Widgets.JoseCarousel.Components;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Nop.Core;
using Nop.Core.Domain.Cms;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Custom.Plugin.Widgets.JoseCarousel;

public class JoseCarouselPlugin : BasePlugin,  IWidgetPlugin
{
    #region Fields
    
    protected readonly IActionContextAccessor _actionContextAccessor;
    protected readonly ILocalizationService _localizationService;
    protected readonly ISettingService _settingService;
    protected readonly IUrlHelperFactory _urlHelperFactory;
    protected readonly IWebHelper _webHelper;
    protected readonly WidgetSettings _widgetSettings;
    
    #endregion
    
    #region Ctor
    public JoseCarouselPlugin(IActionContextAccessor actionContextAccessor, ILocalizationService localizationService,
        ISettingService settingService,
        IUrlHelperFactory urlHelperFactory, IWebHelper webHelper, WidgetSettings widgetSettings)
    {
        _actionContextAccessor = actionContextAccessor;
        _localizationService = localizationService;
        _settingService = settingService;
        _urlHelperFactory = urlHelperFactory;
        _webHelper = webHelper;
        _widgetSettings = widgetSettings;
    }
    
    #endregion
    
    #region Properties
    public bool HideInWidgetList => false;
    
    #endregion
    
    #region Methods
    public Task<IList<string>> GetWidgetZonesAsync()
    {
        return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.HomepageTop });
    }
    public override string GetConfigurationPageUrl()
    {
        return _webHelper.GetStoreLocation() + "Admin/WidgetJoseCarousel/Configure";
    }
    public Type GetWidgetViewComponent(string widgetZone)
    {
        return typeof(WidgetJoseCarouselViewComponent);
    }
    
    #endregion
}