using ABPCourse.Demo1.Samples;
using Xunit;

namespace ABPCourse.Demo1.EntityFrameworkCore.Applications;

[Collection(Demo1TestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<Demo1EntityFrameworkCoreTestModule>
{

}
