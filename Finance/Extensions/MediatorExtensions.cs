using System.Reflection;

namespace Finance.Extensions
{

    public static class MediatorExtensions
    {
        public static IServiceCollection AddMediatorToUseCases(this IServiceCollection services, string partOfAssemblyName = "Application")
        {
            ServiceCollectionExtensions.AddMediatR(services,
                cfg => cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(
                    (Assembly assembly) => assembly.GetName().Name!.Contains(partOfAssemblyName)
                    ))
            );

            return services;
        }
    }
}
