using ABPCourse.Demo1.Bases;
using ABPCourse.Demo1.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Authorization;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace ABPCourse.Demo1.Products
{
    public class ProductsAppService : BaseApplicationService, IProductsAppService
    {
        #region fields
        private readonly IRepository<Product, int> productsRepository;
        private readonly IStringLocalizerFactory localizerFactory;
        private readonly IProductService productService;
        private readonly ITenantRepository tenantsRepo;
        private readonly IRepository<TenantConnectionString> tenantConnectionStrings;
        private readonly IDataFilter dataFilter;
        #endregion

        #region constructor
        public ProductsAppService(IRepository<Product, int> productsRepository,
            IStringLocalizerFactory localizerFactory,
            IProductService productService, 
            ITenantRepository tenantsRepo,
            IRepository<TenantConnectionString> tenantConnectionStrings,
            IDataFilter dataFilter)
        {
            this.productsRepository = productsRepository;
            this.localizerFactory = localizerFactory;
            this.productService = productService;
            this.tenantsRepo = tenantsRepo;
            this.tenantConnectionStrings = tenantConnectionStrings;
            this.dataFilter = dataFilter;
        }
        #endregion constructor

        #region IProductsAppService
        //[Authorize(Demo1Permissions.CreateEditProductPermission)]
        public async Task<ProductDto> CreateProductAsync(CreateUpdateProductDto input)
        {
            //validation
            var validateResult = new CreateUpdateProductValidator(localizerFactory).Validate(input);
            if(!validateResult.IsValid)
            {
                var exception = GetValidationException(validateResult);
                throw exception;
            }

            var product = ObjectMapper.Map<CreateUpdateProductDto, Product>(input);

            //check if product exists
            var exists = await productService.Exists(product);
            if (exists)
            {
                throw new ProductAlreadyExistsException(product.NameEn);
            }

            var inserted = await productsRepository.InsertAsync(product, autoSave: true);
            return ObjectMapper.Map<Product, ProductDto>(inserted);
        }

        //[Authorize(Demo1Permissions.CreateEditProductPermission)]
        public async Task<ProductDto> UpdateProductAsync(CreateUpdateProductDto input)
        {
            //validation
            var validateResult = new CreateUpdateProductValidator(localizerFactory).Validate(input);
            if (!validateResult.IsValid)
            {
                var exception = GetValidationException(validateResult);
                throw exception;
            }

            var existing = await productsRepository.GetAsync(input.Id);
            if (existing == null) 
            {
                throw new ProductNotFoundException(input.Id);
            }
            var mapped= ObjectMapper.Map<CreateUpdateProductDto, Product>(input, existing);
            var updated = await productsRepository.UpdateAsync(mapped, autoSave: true);
            return ObjectMapper.Map<Product, ProductDto>(updated);
        }


        //[Authorize(Demo1Permissions.DeleteProductPermission)]
        public async Task<bool> DeleteProductAsync(int id)
        {
            var existingProduct = await productsRepository.GetAsync(id);
            if(existingProduct == null)
            {
                throw new ProductNotFoundException(id);
            }

            await productsRepository.DeleteAsync(existingProduct);
            return true;
        }

        [Authorize(Demo1Permissions.ListProductPermission)]
        public async Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Product.Id);
            }

            var products = await productsRepository
                .WithDetailsAsync(product => product.Category)
                .Result
                .AsQueryable()
                .WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    product => product.NameAr.Contains(input.Filter) ||
                               product.NameEn.Contains(input.Filter)
                )
                .WhereIf(
                    input.CategoryId.HasValue,
                    product => product.CategoryId == input.CategoryId
                )
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .OrderBy(input.Sorting)
                .ToListAsync();
            
            var totalCount = input.Filter == null
                ? await productsRepository.CountAsync()
                : await productsRepository.CountAsync(product => product.NameAr.Contains(input.Filter) ||
                                                                 product.NameEn.Contains(input.Filter));

            return new PagedResultDto<ProductDto>(
                totalCount,
                ObjectMapper.Map<List<Product>, List<ProductDto>>(products)
            );
        }

        [Authorize(Demo1Permissions.GetProductPermission)]
        public async Task<ProductDto> GetProductAsync(int id)
        {
            var product = await productsRepository
                           .WithDetailsAsync(x => x.Category)
                           .Result
                           .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                throw new ProductNotFoundException(id);
            }
            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        [AllowAnonymous]
        public Task<bool> LabTestProductAsync(int id)
        {
            //call lab test service

            return Task.FromResult(true);
        }

        public async Task<bool> TestComplexPermissions()
        {
            var result = await AuthorizationService.AuthorizeAsync(Demo1Permissions.CreateEditProductPermission);
            if (result.Succeeded == false)
            {
                //throw exception
                throw new AbpAuthorizationException("You don't have permission for this action");
            }

            return true;
        }

        public async Task<Dictionary<string, int>> GetProductsOfTenant()
        {
            var result = new Dictionary<string, int>();

            var tenants = await tenantsRepo.GetListAsync();

            foreach (var t in tenants)
            {
                using (CurrentTenant.Change(t.Id))
                {
                    result.Add($"{t.Name} Products", await productsRepository.CountAsync());
                }
            }

            //Get count on all tenants
            using (dataFilter.Disable<IMultiTenant>())
            {
                result.Add("All Products Count", await productsRepository.CountAsync());
            }

            return result;
        }

        public async Task ChangeTenantsConnectionString()
        {
            var tenants = await tenantsRepo.GetListAsync();

            foreach (var t in tenants)
            {
                var connstr = $"Server=.;Database=Demo1_{t.Name};Trusted_Connection=True;TrustServerCertificate=True";
                await tenantConnectionStrings.InsertAsync(new TenantConnectionString(t.Id, ConnectionStrings.DefaultConnectionStringName, connstr));
            }
        }

        #endregion IProductsAppService
    }
}

