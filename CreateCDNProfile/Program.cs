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
        static string clientId = "c6764c13-4613-4725-89de-b64ccd9d6c45";
        static string clientSecret = "Di:B]B5653IebJCTI?bfRh-TBPh/H-Xn";
        static string tenantID = "b388b808-0ec9-4a09-a414-a7cbbd8b7e9b";
        static void Main(string[] args)
        {
            string url = "https://management.chinacloudapi.cn/subscriptions/86d19745-1e57-4bdf-be8d-c17e3792c594/resourceGroups/testgroup1/providers/Microsoft.Cdn/profiles/myprofile3?api-version=2019-04-15";
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
                       new AuthenticationContext("https://login.chinacloudapi.cn/b388b808-0ec9-4a09-a414-a7cbbd8b7e9b");
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
        //public static string CreateCDNProfile()
        //{
        //    var token = gettoken();
        //    var api = "https://management.chinacloudapi.cn/subscriptions/86d19745-1e57-4bdf-be8d-c17e3792c594/resourceGroups/testgroup1/providers/Microsoft.Cdn/profiles/myprofile1?api-version=2019-04-15?api-version=2019-05-10";
        //    var http = new HttpClient();
        //    var req = new HttpRequestMessage(HttpMethod.Get, api);
        //    req.Headers.Add("Authorization", "Bearer " + token);
        //    var resp = http.SendAsync(req).Result;
        //    if (resp.IsSuccessStatusCode)
        //    {
        //        var json = JsonConvert.DeserializeObject<JObject>(resp.Content.ReadAsStringAsync().Result);

        //        return json["value"].ToString();
        //    }
        //    return "";

        //}
        
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
        //private static string GetToken()
        //{
        //    try
        //    {
        //        var client = new HttpClient();
        //        var request = new HttpRequestMessage(HttpMethod.Post, "https://login.chinacloudapi.cn/tentid/oauth2/token?api-version=1.0");
        //        var dictionary = new Dictionary<string, string>
        //    {
        //        {"resource","https://microsoftgraph.chinacloudapi.cn/" },
        //        {"client_id","值" },
        //        {"grant_type","client_credentials" },
        //        {"client_secret","值" }

        //    };
        //        request.Content = new FormUrlEncodedContent(dictionary);
        //        var result = client.SendAsync(request).Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var json = JsonConvert.DeserializeObject<JObject>(result.Content.ReadAsStringAsync().Result);
        //            return json["access_token"].ToString();
        //        }
        //        return string.Empty;
        //    }
        //    catch
        //    {
        //        return string.Empty;
        //    }
        //}

        //public static async Task<string> PostAsyncJson(string url, string json)
        //{
        //    HttpClient client = new HttpClient();
        //    HttpContent content = new StringContent(json);
        //    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        //    HttpResponseMessage response = await client.PostAsync(url, content);
        //    response.EnsureSuccessStatusCode();
        //    string responseBody = await response.Content.ReadAsStringAsync();
        //    return responseBody;
        //}
        //public static string GetAccessTokenAsync()
        //{
        //    AuthenticationContext context = new
        //    AuthenticationContext(
        //        string.Format("https://login.chinacloudapi.cn/b388b808-0ec9-4a09-a414-a7cbbd8b7e9b/oauth2/token?api-version=1.0"));
        //    var credential = new ClientCredential("4ab4cad5-e3b4-4b13-8a43-3dd88be080aa", "R:b/3?4AJ3rQ@6wLjms8ch.8w3J=OkIC");
        //    AuthenticationResult authenticationResult =
        //    context.AcquireTokenAsync(
        //        "https://management.chinacloudapi.cn/",
        //        credential).GetAwaiter().GetResult();
        //    return authenticationResult.AccessToken;
        //}


    }
}
