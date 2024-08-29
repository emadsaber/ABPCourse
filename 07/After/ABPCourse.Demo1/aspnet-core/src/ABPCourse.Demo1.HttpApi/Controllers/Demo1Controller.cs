using ABPCourse.Demo1.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ABPCourse.Demo1.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class Demo1Controller : AbpControllerBase
{
    protected Demo1Controller()
    {
        LocalizationResource = typeof(Demo1Resource);
    }
}
