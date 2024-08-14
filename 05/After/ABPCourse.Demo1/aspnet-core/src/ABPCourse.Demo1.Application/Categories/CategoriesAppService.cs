using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ABPCourse.Demo1.Categories
{
    public class CategoriesAppService :
        CrudAppService<Category,
                       CategoryDto,
                       int,
                       PagedAndSortedResultRequestDto,
                       CreateUpdateCategoryDto>,
        ICategoriesAppService
    {

        #region constructor
        public CategoriesAppService(IRepository<Category, int> repository) : base(repository)
        {
        }
        #endregion constructor
    }
}
