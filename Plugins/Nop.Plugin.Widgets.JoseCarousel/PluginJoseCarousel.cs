using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Services.Security;
using Nop.Web.Framework.Events;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Widgets.JoseCarousel;

public class PluginJoseCarousel : BasePlugin, IWidgetPlugin
{
    public bool HideInWidgetList => false;
    
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
            SystemName = "Carousel Plugin",
            Title = "Carousel Plugin",
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