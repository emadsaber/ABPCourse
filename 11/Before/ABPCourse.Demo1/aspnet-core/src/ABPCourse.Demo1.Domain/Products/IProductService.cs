using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ABPCourse.Demo1.Products
{
    public interface IProductService : ITransientDependency
    {
        Task<bool> Exists(Product product);
    }
}
