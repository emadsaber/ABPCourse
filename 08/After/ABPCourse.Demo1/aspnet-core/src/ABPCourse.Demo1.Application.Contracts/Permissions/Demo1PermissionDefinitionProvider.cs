using ABPCourse.Demo1.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ABPCourse.Demo1.Permissions;

public class Demo1PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(Demo1Permissions.MainGroupName);
        var productGroup = context.AddGroup(Demo1Permissions.ProductGroupName, L("Demo1.Products"));
        productGroup.AddPermission(Demo1Permissions.CreateEditProductPermission, L("Permission:Products:CreateEditProduct"));
        productGroup.AddPermission(Demo1Permissions.DeleteProductPermission, L("Permission:Products:DeleteProduct"));
        productGroup.AddPermission(Demo1Permissions.GetProductPermission, L("Permission:Products:GetProduct"));
        productGroup.AddPermission(Demo1Permissions.ListProductPermission, L("Permission:Products:ListProduct"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProductsResource>(name);
    }
}
