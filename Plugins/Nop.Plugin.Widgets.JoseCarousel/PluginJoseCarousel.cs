using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Widgets.JoseCarousel;

public class PluginJoseCarousel : BasePlugin, IWidgetPlugin, IAdminMenuPlugin
{
    public bool HideInWidgetList => false;
    public string GetConfigurationPageUrl()
    {
        throw new NotImplementedException();
    }

    public PluginDescriptor PluginDescriptor { get; set; }
    public Task InstallAsync()
    {
        throw new NotImplementedException();
    }

    public Task UninstallAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string currentVersion, string targetVersion)
    {
        throw new NotImplementedException();
    }

    public Task PreparePluginToUninstallAsync()
    {
        throw new NotImplementedException();
    }

    public async Task ManageSiteMapAsync(AdminMenuItem rootNode)
    {
        var customPluginsMenu = rootNode.ChildNodes.FirstOrDefault(node => node.SystemName.Equals("Custom Plugins"));

        if (customPluginsMenu == null)
        {
            rootNode.ChildNodes.Add(new AdminMenuItem()
            {
                Visible = true,
                SystemName = "Custom Plugin Menu",
                Title = "Custom Plugins",
                IconClass = "fa fa-cubes"
            });
            
            customPluginsMenu = rootNode.ChildNodes.FirstOrDefault(node => node.SystemName.Equals("Custom Plugins"));
        }

        customPluginsMenu!.ChildNodes.Add(new AdminMenuItem()
        {
            Visible = true,
            SystemName = "Carousel Image Plugins",
            Title = "Carousel Image",
            IconClass = "fa icon-plugins"
        });
    }
    

    
    public Task<IList<string>> GetWidgetZonesAsync()
    {
        throw new NotImplementedException();
    }

    public Type GetWidgetViewComponent(string widgetZone)
    {
        throw new NotImplementedException();
    }
}