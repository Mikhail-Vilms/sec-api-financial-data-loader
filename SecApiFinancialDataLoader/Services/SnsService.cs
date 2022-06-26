using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecApiFinancialDataLoader.Services
{
    public class SnsService : ISnsService
    {
        private readonly string _snsArn = "arn:aws:sns:us-west-2:672009997609:Sec-Api-Financial-Statements-To-Load";

        public async Task PublishFinancialStatementsToLoadAsync(string snsMsgJsonStr)
        {
            using (var client = new AmazonSimpleNotificationServiceClient(region: RegionEndpoint.USWest2))
            {
                var request = new PublishRequest(_snsArn, snsMsgJsonStr);
                await client.PublishAsync(request);
            }
        }

        public async Task PublishFinancialStatementsToLoadAsync(IList<string> snsMessages)
        {
            using (var client = new AmazonSimpleNotificationServiceClient(region: RegionEndpoint.USWest2))
            {
                foreach (string snsMsgJsonStr in snsMessages)
                {
                    var request = new PublishRequest(_snsArn, snsMsgJsonStr);
                    await client.PublishAsync(request);
                }
            }
        }
    }
}
