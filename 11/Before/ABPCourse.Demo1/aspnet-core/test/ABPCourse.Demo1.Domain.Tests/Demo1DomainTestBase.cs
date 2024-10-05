using Volo.Abp.Modularity;

namespace ABPCourse.Demo1;

/* Inherit from this class for your domain layer tests. */
public abstract class Demo1DomainTestBase<TStartupModule> : Demo1TestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
