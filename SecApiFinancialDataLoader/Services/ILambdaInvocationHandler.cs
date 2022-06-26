using Amazon.Lambda.Core;
using System.Threading.Tasks;

namespace SecApiFinancialDataLoader.Services
{
    public interface ILambdaInvocationHandler
    {
        Task FunctionHandler(string message, ILambdaContext context);
    }
}
