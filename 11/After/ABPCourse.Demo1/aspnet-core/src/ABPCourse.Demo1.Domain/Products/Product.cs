using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace ABPCourse.Demo1;

public class Product : FullAuditedEntity<int>, IMultiTenant
{
    public string NameAr { get; set; }

    public string NameEn { get; set; }

    public string DescriptionAr { get; set; }

    public string DescriptionEn { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }
    public Guid? TenantId { get; set; }

}
