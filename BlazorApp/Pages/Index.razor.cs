using Grpc.Net.Client;
using Grpc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public partial class Index
    {
        private string InitialMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new Test.TestClient(channel);
            var reply = await client.DoAsync(
                              new Request { Message = this.ToString() });

            InitialMessage = reply.Message;
        }
    }
}
