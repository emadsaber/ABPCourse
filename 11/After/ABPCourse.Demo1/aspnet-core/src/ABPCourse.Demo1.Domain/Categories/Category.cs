using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace ABPCourse.Demo1;

public class Category : FullAuditedEntity<int>, IMultiTenant
{
    public Category(string nameAr, string nameEn, string descriptionAr, string descriptionEn) 
    {
        NameAr = nameAr;
        NameEn = nameEn;
        DescriptionAr = descriptionAr;
        DescriptionEn = descriptionEn;
    }

    public string NameAr { get; set; }

    public string NameEn { get; set; }
    
    public string DescriptionAr { get; set; }
    
    public string DescriptionEn { get; set; }

    public Guid? TenantId { get; set; }
}
