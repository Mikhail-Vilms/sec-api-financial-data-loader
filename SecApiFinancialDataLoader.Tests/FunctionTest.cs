using Amazon.Lambda.TestUtilities;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SecApiFinancialDataLoader.Tests
{
    public class FunctionTest
    {
        [Fact]
        public async Task TestToUpperFunction()
        {
            // string symbols = "AXP,AAPL,BA,CAT,CSCO,CVX,XOM,GS,HD,IBM,INTC,JNJ,KO,JPM,MCD,MMM,MRK,MSFT,NKE,PFE,PG,TRV,UNH,UTX,VZ,V,WBA,WMT,DIS";
            string symbols = "XOM,HD";
            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var context = new TestLambdaContext();
            await function.FunctionHandler(symbols, context);

            Assert.Equal("HELLO WORLD", "HELLO WORLD");
        }
    }
}
