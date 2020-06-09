using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CreateCDNProfile
{
    class Program
    {
        static string clientId = "Your-Client-ID";
        static string clientSecret = "Your-Client-Secret";
        static string tenantID = "Your-TenantID";
        static void Main(string[] args)
        {
            string url = "https://management.chinacloudapi.cn/subscriptions/Your-SubID/resourceGroups/Your-esource-Group-Name/providers/Microsoft.Cdn/profiles/Your-CDN-Profile-Name?api-version=2019-04-15";
            string cdnjson = "{\r\n  \"location\": \"Chinanorth\",\r\n  \"sku\": {\r\n    \"name\": \"Premium_ChinaCdn\"\r\n  }\r\n}";
            PutCreateCDNProfile(url,cdnjson);
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
        public static string gettoken()
        {
            try
            {
                AuthenticationContext authContext =
                       new AuthenticationContext("https://login.chinacloudapi.cn/Your-TenantID");
                ClientCredential credential = new ClientCredential(clientId, clientSecret);
                AuthenticationResult result =
                 authContext.AcquireTokenAsync("https://management.chinacloudapi.cn/", credential).GetAwaiter().GetResult();
                return result.AccessToken;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        
        public static string PutCreateCDNProfile(string url, string cdnjson)
        {
            var token = gettoken();
            HttpClient client = new HttpClient();

            
            var http = new HttpClient();
            var req = new HttpRequestMessage(HttpMethod.Put, url);
            req.Headers.Add("Authorization", "Bearer " + token);

            HttpContent content = new StringContent(cdnjson);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            req.Content = content;

            var result = client.SendAsync(req).Result;
           if (result.IsSuccessStatusCode)
            {
                return "succeed";
            }
            return "failed";
        }
       
    }
}
