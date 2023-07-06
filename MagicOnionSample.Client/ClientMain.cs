// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Grpc.Core;
using Grpc.Net.Client;
using MagicOnion.Client;
using MagicOnionSample.ServiceDefinition;

var channel = GrpcChannel.ForAddress("http://localhost:5194");
var client = MagicOnionClient.Create<ISampleApi>(channel);

#if false // Unary通信
// 0 - 100の整数乱数を2つ生成する
for (int i = 0; i < 100; ++i)
{
    // 処理にかかる時間を計測する
    var sw = Stopwatch.StartNew();
    
    var rand = new Random();
    var x = rand.Next(0, 100);
    var y = rand.Next(0, 100);
    var result = await client.Sum(x, y);
    Console.WriteLine($"Result: {x} + {y} = {result} ({sw.ElapsedMilliseconds})");
}
#elif true // Server Streaming通信
await ServerStreamingComm(client);
#endif

static async Task ServerStreamingComm(ISampleApi client)
{
    var streaming = await client.Repeat(3, 10);
    await foreach (var res in streaming.ResponseStream.ReadAllAsync())
    {
        Console.WriteLine("ServerStreaming: " + res);
    }
}

