// Copyright 2015 gRPC authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Diagnostics;
using Grpc.Core;
using Helloworld;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GreeterClient
{
    class Program
    {
        public static void Main(string[] args)
        {

            //Channel channel = new Channel("52.190.8.13:50051", ChannelCredentials.Insecure);
            Channel channel = new Channel("localhost:50051", ChannelCredentials.Insecure);


            var client = new Greeter.GreeterClient(channel);

            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine(" ... calling server 100 times ... hang on ...");
            for (int i = 0; i < 100; i++)
            {
                PersonsRequest prs = new PersonsRequest { Count = "1000" };
                var p2 = client.GetPersons(prs);
                List<Person> Persons = GetPersons(p2).Result;
                Console.WriteLine(Persons.Count);
            }

            stopwatch.Stop();
            Console.WriteLine("Elapsed time {0} ms",stopwatch.ElapsedMilliseconds);
            
            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();



        }
        public static async Task<List<Person>> GetPersons(AsyncServerStreamingCall<Person> c) {
            List<Person> p = new List<Person>();
            while (await c.ResponseStream.MoveNext(CancellationToken.None))
            {
                p.Add(c.ResponseStream.Current);
            }
            return p;
        }
    }
}
