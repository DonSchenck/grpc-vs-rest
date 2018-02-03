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
            string url = "http://localhost:5000/api/values/";
            string username = "REST client";
            Stopwatch stopwatch = Stopwatch.StartNew();
             for (int i=0; i < 1000; i++) {
                string resultString = GetIt(url,username).Result;
                Console.WriteLine("Hello number " + i.ToString() + ": " + resultString);
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
