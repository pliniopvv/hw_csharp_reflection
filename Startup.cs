using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace hw_attributes
{
    public abstract class Startup
    {
        public static void Configure(IServiceCollection services)
        {
            
        }

        public static void Configure<I, T>(IServiceCollection service)
            where I : class
            where T : class, I
        {
            service.AddTransient<I, T>();
        }
    }
}
