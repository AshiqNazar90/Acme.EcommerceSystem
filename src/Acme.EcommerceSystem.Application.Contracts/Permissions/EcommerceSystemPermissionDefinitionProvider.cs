using Acme.EcommerceSystem.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.EcommerceSystem.Permissions;

public class EcommerceSystemPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(EcommerceSystemPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(EcommerceSystemPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EcommerceSystemResource>(name);
    }
}
