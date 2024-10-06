using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ABPCourse.Demo1.Data
{
    public class CategoryDataSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Category, int> categoriesRepository;

        public CategoryDataSeeder(IRepository<Category, int> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (!await categoriesRepository.AnyAsync())
            {
                var categories = new List<Category>()
            {
                new Category(nameAr:"أطعمة ومشروبات",
                            nameEn: "Food & Drinks",
                            descriptionAr:"جميع أنواع الأطعمة والمشروبات",
                            descriptionEn: "All food and drink categories"),
                new Category(nameAr:"مواد تنظيف",
                             nameEn: "Detergents",
                             descriptionAr:"المنظفات بأنواعها",
                             descriptionEn: "all materials used for cleaning"),
                new Category(nameAr:"عطور",
                             nameEn: "Fragrances",
                             descriptionAr:"العطور بأنواعها",
                             descriptionEn: "all perfumes and its sub-categories"),
                new Category(nameAr:"بلاستيك",
                             nameEn: "Plastic",
                             descriptionAr:"البلاستيك القابل للتدوير والغير قابل للتدوير",
                             descriptionEn: "all reusable and non-reusable plastic materials"),
            };

                await this.categoriesRepository.InsertManyAsync(categories);
            }
        }
    }
}
