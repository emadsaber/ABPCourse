using Volo.Abp.Settings;

namespace ABPCourse.Demo1.Settings;

public class Demo1SettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(Demo1Settings.MySetting1));
    }
}
