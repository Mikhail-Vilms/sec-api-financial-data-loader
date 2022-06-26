using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecApiFinancialDataLoader.Persistence;
using SecApiFinancialDataLoader.Services;

namespace SecApiFinancialDataLoader
{
    public static class Startup
    {
        internal static IHostBuilder SetupHostForLambda(this IHostBuilder hostBuilder) => hostBuilder
            .AddRuntimeDependenciesBinding();

        private static IHostBuilder AddRuntimeDependenciesBinding(this IHostBuilder hostBuilder) => hostBuilder
            .ConfigureServices((context, serviceCollection) => serviceCollection
                .AddSingleton<ILambdaInvocationHandler, LambdaInvocationHandler>()
                .AddSingleton<IFinancialDataLoader, FinancialDataLoader>()
                .AddSingleton<IDynamoRepo, DynamoRepo>()
                .AddSingleton<ISnsService, SnsService>());
    }
}
