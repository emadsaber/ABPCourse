using Volo.Abp;

namespace ABPCourse.Demo1.Products
{
    public class ProductAlreadyExistsException: BusinessException
    {
        public ProductAlreadyExistsException(string nameEn) : base(Demo1DomainErrorCodes.PRODUCT_ALREADY_EXISTS)
        {
            WithData("nameEn", nameEn);        
        }
    }
}
