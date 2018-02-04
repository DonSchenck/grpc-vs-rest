using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

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
            for (int i=0; i < 1000; i++) {
                var resultString = GetIt(url,username).Result;
                if (i == 500) {
                    Console.WriteLine("Hello number " + i.ToString() + ": " + resultString);
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
