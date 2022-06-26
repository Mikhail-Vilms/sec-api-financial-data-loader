using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecApiFinancialDataLoader.Services
{
    public interface ISnsService
    {
        public Task PublishFinancialStatementsToLoadAsync(string snsMsgJsonStr);
        public Task PublishFinancialStatementsToLoadAsync(IList<string> snsMessages);
    }
}
