using Volo.Abp.Application.Dtos;

namespace ABPCourse.Demo1.Products
{
    public class GetProductListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public int? CategoryId { get; set; } 
    }
}
