using System.Threading.Tasks;

namespace ABPCourse.Demo1.Data;

public interface IDemo1DbSchemaMigrator
{
    Task MigrateAsync();
}
