using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;

namespace ABPCourse.Demo1.Products
{
    public class ProductService : IProductService
    {
        private readonly IAuditingManager _auditingManager;
        private readonly IRepository<Product, int> productRepo;

        public ProductService(IAuditingManager auditingManager, IRepository<Product, int> productRepo)
        {
            this._auditingManager = auditingManager;
            this.productRepo = productRepo;
        }

        public Task<bool> Exists(Product product)
        {
            var currentAuditLogScope = _auditingManager.Current;
            if (currentAuditLogScope != null)
            {
                currentAuditLogScope.Log.Comments.Add(
                    $"Checking if product {product.NameEn} exists"
                );

                currentAuditLogScope.Log.SetProperty("NameEn", product.NameEn);
            }

            return productRepo.AnyAsync(x => x.NameEn == product.NameEn);
        }
    }
}
