using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ABPCourse.Demo1.Data;
using Volo.Abp.DependencyInjection;

namespace ABPCourse.Demo1.EntityFrameworkCore;

public class EntityFrameworkCoreDemo1DbSchemaMigrator
    : IDemo1DbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreDemo1DbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the Demo1DbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<Demo1DbContext>()
            .Database
            .MigrateAsync();
    }
}
