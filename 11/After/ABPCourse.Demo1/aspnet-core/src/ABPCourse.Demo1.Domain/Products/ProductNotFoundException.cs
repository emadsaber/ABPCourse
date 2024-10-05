using Volo.Abp;

namespace ABPCourse.Demo1.Products
{
    public class ProductNotFoundException: BusinessException
    {
        public ProductNotFoundException(int id) : base(Demo1DomainErrorCodes.PRODUCT_NOT_FOUND)
        {
            WithData("id", id);        
        }
    }
}
