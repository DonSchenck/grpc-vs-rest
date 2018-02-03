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

namespace GreeterClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            Stopwatch stopwatch = Stopwatch.StartNew();

            var client = new Greeter.GreeterClient(channel);
            String user = "from the gRPC server";

            for (int i = 0; i < 1000; i++)
            {
                var reply = client.SayHello(new HelloRequest { Name = user });
                Console.WriteLine("Greeting number " + i.ToString() + ": " + reply.Message);
            }

            stopwatch.Stop();
            Console.WriteLine("Elapsed time {0} ms",stopwatch.ElapsedMilliseconds);
            
            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
