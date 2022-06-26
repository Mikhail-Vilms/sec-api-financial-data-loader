using Amazon.Lambda.Core;
using System.Threading.Tasks;

namespace SecApiFinancialDataLoader.Services
{
    public class LambdaInvocationHandler: ILambdaInvocationHandler
    {
        private readonly IFinancialDataLoader _financialDataLoader;

        public LambdaInvocationHandler(IFinancialDataLoader financialDataLoader)
        {
            _financialDataLoader = financialDataLoader;
        }

        public async Task FunctionHandler(string message, ILambdaContext context)
        {
            void Log(string logMessage)
            {
                context.Logger.LogLine($"[RequestId: {context.AwsRequestId}]: {logMessage}");
            }

            Log($">>> >>> >>> Processing message: {message}");

            await _financialDataLoader.Load(message, Log);

            Log($"Finished Processing <<< <<< <<<");
        }
    }
}
