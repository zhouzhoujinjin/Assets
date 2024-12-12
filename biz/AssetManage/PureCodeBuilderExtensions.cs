using PureCode.Core;
using Microsoft.Extensions.DependencyInjection;


namespace AssetManage
{
  public static class PureCodeBuilderExtensions
  {
    public static PureCodeServiceCollectionBuilder WithAsset(this PureCodeServiceCollectionBuilder builder)
    {
      builder.Services.AddScoped<AssetManager>();
      //builder.AddTreeType(DepartmentManager.TreeType);
      return builder;
    }
  }
}
