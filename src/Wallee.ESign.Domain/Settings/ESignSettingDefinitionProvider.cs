using Volo.Abp.Settings;

namespace Wallee.ESign.Settings;

public class ESignSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        /* Define module settings here.
         * Use names from ESignSettings class.
         */

        context.Add(new SettingDefinition(ESignSettings.Telecom3FactorsGrade, defaultValue: "STANDARD", isVisibleToClients: true));
    }
}
