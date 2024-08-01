using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ABPCourse.Demo1.Categories
{
    public interface ICategoriesAppService : ICrudAppService< //Defines CRUD methods
        CategoryDto, //Used to show categories
        int, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCategoryDto> //Used to create/update a category
    {
    }
}
