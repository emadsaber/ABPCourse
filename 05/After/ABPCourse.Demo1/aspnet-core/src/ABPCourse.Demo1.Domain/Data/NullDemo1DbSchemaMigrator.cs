using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ABPCourse.Demo1.Data;

/* This is used if database provider does't define
 * IDemo1DbSchemaMigrator implementation.
 */
public class NullDemo1DbSchemaMigrator : IDemo1DbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
