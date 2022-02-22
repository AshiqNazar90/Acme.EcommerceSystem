using Volo.Abp.Settings;

namespace Acme.EcommerceSystem.Settings;

public class EcommerceSystemSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(EcommerceSystemSettings.MySetting1));
    }
}
