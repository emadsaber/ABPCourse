namespace ABPCourse.Demo1.Permissions;

public static class Demo1Permissions
{
    public const string MainGroupName = "Demo1";

    //Product Group & Permissions
    public const string ProductGroupName = MainGroupName + ".Products";
    public const string CreateEditProductPermission = ProductGroupName + ".CreateEdit";
    public const string DeleteProductPermission = ProductGroupName + ".Delete";
    public const string GetProductPermission = ProductGroupName + ".Get";
    public const string ListProductPermission = ProductGroupName + ".List";
}
