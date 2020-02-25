using Grpc.Core;
using Grpc.Service;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrpcService.Server
{
    public class TestService : Test.TestBase
    {
        //public TestService(ILogger logger)
        //{
        //    this.Loger = logger;
        //}

        //public ILogger Loger { get; }

        public override Task<Response> Do(Request request, ServerCallContext context)
        {
            IDictionary<string, object> responseData = new Dictionary<string, object>
            {
                ["request"] = request.Message
            };

            return Task.FromResult<Response>(new Response()
            {
                Message = JsonConvert.SerializeObject(responseData)
            });
        }
    }
}
