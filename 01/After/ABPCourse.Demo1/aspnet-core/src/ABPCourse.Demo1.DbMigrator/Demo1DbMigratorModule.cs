using ABPCourse.Demo1.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ABPCourse.Demo1.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(Demo1EntityFrameworkCoreModule),
    typeof(Demo1ApplicationContractsModule)
    )]
public class Demo1DbMigratorModule : AbpModule
{
}
