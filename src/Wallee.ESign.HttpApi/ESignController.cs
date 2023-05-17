using Wallee.ESign.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Wallee.ESign;

public abstract class ESignController : AbpControllerBase
{
    protected ESignController()
    {
        LocalizationResource = typeof(ESignResource);
    }
}
