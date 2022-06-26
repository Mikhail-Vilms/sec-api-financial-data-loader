using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecApiFinancialDataLoader.Services;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SecApiFinancialDataLoader
{
    public class Function
    {
        private readonly ILambdaInvocationHandler _lambdaInvocationHandler;

        public Function()
        {
            var host = new HostBuilder()
                .SetupHostForLambda()
                .Build();

            var serviceProvider = host.Services;

            _lambdaInvocationHandler = serviceProvider
                .GetRequiredService<ILambdaInvocationHandler>();
        }

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task FunctionHandler(string message, ILambdaContext context)
        {
            await _lambdaInvocationHandler.FunctionHandler(message, context);
        }
    }
}
