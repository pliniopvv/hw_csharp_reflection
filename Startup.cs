using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace hw_attributes
{
    public abstract class Startup
    {
        static Assembly assembly = Assembly.GetCallingAssembly();
        public static void Configure(IServiceCollection services)
        {
            
        }

        public static void Configure<I, T>(IServiceCollection service)
            where I : class
            where T : class, I
        {
            service.AddTransient<I, T>();
        }

        public static void Configure(IServiceCollection service, Type um, Type dois)
        {
            ServiceDescriptor sd = ServiceDescriptor.Transient(um, dois);
            service.Add(sd);
        }
    }
}
