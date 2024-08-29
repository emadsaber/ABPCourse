import type { EntityDto, FullAuditedEntityDto } from '@abp/ng.core';

export interface CategoryDto extends FullAuditedEntityDto<number> {
  nameAr?: string;
  nameEn?: string;
  descriptionAr?: string;
  descriptionEn?: string;
}

export interface CreateUpdateCategoryDto extends EntityDto<number> {
  nameAr: string;
  nameEn: string;
  descriptionAr: string;
  descriptionEn: string;
}
