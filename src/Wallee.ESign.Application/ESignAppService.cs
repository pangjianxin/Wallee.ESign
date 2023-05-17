using Wallee.ESign.Localization;
using Volo.Abp.Application.Services;

namespace Wallee.ESign;

public abstract class ESignAppService : ApplicationService
{
    protected ESignAppService()
    {
        LocalizationResource = typeof(ESignResource);
        ObjectMapperContext = typeof(ESignApplicationModule);
    }
}
