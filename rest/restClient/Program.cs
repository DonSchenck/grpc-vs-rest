using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace restClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            string url = "http://52.190.8.13:5000/api/values/";
            string username = "REST client";
            Console.WriteLine("... making 1,000 REST calls ... be right back ...");
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i=0; i < 300; i++) {
                var resultJson = GetIt(url,username).Result;
                if (i == 150) {
                    Console.WriteLine("Hello number " + i.ToString() + ": " + JsonConvert.DeserializeObject(resultJson));
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Elapsed time {0} ms",stopwatch.ElapsedMilliseconds); 
        }
        private static async Task<string> GetIt(string url, string username)
        {
            var stringTask = client.GetStringAsync(url+username);
            var msg = await stringTask;
            return msg;
        }
    }
}
