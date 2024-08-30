using Microsoft.Extensions.Caching.StackExchangeRedis;
using System;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FluentValidation;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace ABPCourse.Demo1;

[DependsOn(
    typeof(Demo1DomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(Demo1ApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpFluentValidationModule)
    )]
public class Demo1ApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<Demo1ApplicationModule>();
        });

        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = "Demo1_";
            options.GlobalCacheEntryOptions.AbsoluteExpiration = DateTimeOffset.Now.AddHours(1);
        });
    }
}
