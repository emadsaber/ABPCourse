using ABPCourse.Demo1.Bases;
using ABPCourse.Demo1.Categories;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Repositories;

namespace ABPCourse.Demo1.Lookups
{
    public class LookupsAppService : BaseApplicationService
    {
        #region fields
        private readonly IRepository<Category, int> categoryRepository;
        private readonly IDistributedCache<List<CategoryDto>> categoryCache;
        #endregion

        #region ctor
        public LookupsAppService(
            IRepository<Category, int> categoryRepository,
            IDistributedCache<List<CategoryDto>> categoryCache)
        {
            this.categoryRepository = categoryRepository;
            this.categoryCache = categoryCache;
        }
        #endregion

        #region methods
        public async Task<List<CategoryDto>> GetCategories()
        {
            //return await GetAllCategoriesFromDbAsync();
            //return await categoryCache.GetOrAddAsync(
            //    $"ALL_CATEGORIES", //Cache key
            //    async () => await GetAllCategoriesFromDbAsync(),
            //    () => new DistributedCacheEntryOptions
            //    {
            //        AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
            //    }
            //);

            //Using Redis
            return await categoryCache.GetOrAddAsync(
                $"ALL_CATEGORIES", //Cache key
                async () => await GetAllCategoriesFromDbAsync()
            );
        }
        #endregion

        #region private methods
        private async Task<List<CategoryDto>> GetAllCategoriesFromDbAsync()
        {
            var categories = await categoryRepository.GetListAsync();
            return ObjectMapper.Map<List<Category>, List<CategoryDto>>(categories);
        }
        #endregion
    }
}
