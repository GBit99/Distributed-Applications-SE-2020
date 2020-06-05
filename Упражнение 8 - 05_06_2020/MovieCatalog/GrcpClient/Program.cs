using System;
using Grpc.Net.Client;
using GrpcService;

namespace GrcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
            {
                var client = new Greeter.GreeterClient(channel);
                var reply = client.SayHello(new HelloRequest { Name = "Georgi" });

                Console.WriteLine(reply.Message);
            }
        }
    }
}
