using Volo.Abp.Reflection;

namespace Wallee.ESign.Permissions;

public class ESignPermissions
{
    public const string GroupName = "ESign";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ESignPermissions));
    }
}
