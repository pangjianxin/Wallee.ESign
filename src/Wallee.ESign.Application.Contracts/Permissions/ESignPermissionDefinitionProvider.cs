using Wallee.ESign.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Wallee.ESign.Permissions;

public class ESignPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ESignPermissions.GroupName, L("Permission:ESign"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ESignResource>(name);
    }
}
