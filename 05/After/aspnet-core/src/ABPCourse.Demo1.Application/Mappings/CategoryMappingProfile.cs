using ABPCourse.Demo1.Categories;
using AutoMapper;

namespace ABPCourse.Demo1.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CreateUpdateCategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
