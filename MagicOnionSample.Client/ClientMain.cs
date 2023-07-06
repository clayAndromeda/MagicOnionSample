// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Grpc.Net.Client;
using MagicOnion.Client;
using MagicOnionSample.ServiceDefinition;

var channel = GrpcChannel.ForAddress("http://localhost:5194");
var client = MagicOnionClient.Create<ISampleApi>(channel);

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