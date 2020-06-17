using System;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace graphclient
{
    class Program
    {
        private static string clientId = "7262e092-6016-4811-b05a-9612b79a8ab9";
        private static string tenantId = "2fd700b4-94af-4f9f-9a8c-e2971162cf31";
        static async Task Main(string[] args)
        {
            var app = PublicClientApplicationBuilder
                .Create(clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, tenantId)
                .WithRedirectUri("http://localhost")
                .Build();

            var scopes = new List<string> { "user.read" };
            var result = await app.AcquireTokenInteractive(scopes)
                .ExecuteAsync();
            Console.WriteLine($"Token:\t{result.AccessToken}");
        }
    }
}
