using ABPCourse.Demo1.Categories;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ABPCourse.Demo1.Products
{
    public interface IProductsAppService
    {
        Task<ProductDto> CreateProductAsync(CreateUpdateProductDto input);
        
        Task<ProductDto> UpdateProductAsync(CreateUpdateProductDto input);
        
        Task<ProductDto> GetProductAsync(int id);

        Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input);

        Task<bool> DeleteProductAsync(int id);
    }
}
