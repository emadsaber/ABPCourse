using Volo.Abp.Application.Dtos;

namespace ABPCourse.Demo1.Categories
{
    public class CreateUpdateCategoryDto : EntityDto<int>
    {
        public string NameAr { get; set; }

        public string NameEn { get; set; }

        public string DescriptionAr { get; set; }

        public string DescriptionEn { get; set; }
    }
}
