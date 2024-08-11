using ABPCourse.Demo1.Samples;
using Xunit;

namespace ABPCourse.Demo1.EntityFrameworkCore.Domains;

[Collection(Demo1TestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<Demo1EntityFrameworkCoreTestModule>
{

}
