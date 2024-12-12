using Example.Managers;

namespace Example
{
  public static class ServiceCollectionExtensions
  {
    public static void AddExample(this IServiceCollection services)
    {
      services.AddScoped<ConfigManager>();
    }
  }
}
