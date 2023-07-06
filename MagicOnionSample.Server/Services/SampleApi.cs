using MagicOnion;
using MagicOnion.Server;
using MagicOnionSample.ServiceDefinition;

namespace MagicOnionSample.Server.Services;

public class SampleApi : ServiceBase<ISampleApi>, ISampleApi
{
    public async UnaryResult<int> Sum(int x, int y)
    {
        Console.WriteLine($"Sum{x} + {y} = {x + y}");
        await Task.Delay(10);
        return x + y;
    }

    public async Task<ServerStreamingResult<int>> Repeat(int value, int count)
    {
        // Server Streaming通信は、1リクエストに対して複数のレスが返ってくるもの
        Console.WriteLine($"(value, count) = ({value}, {count})");

        // WriteAsyncする度レスポンスが帰ってくる
        var streaming = GetServerStreamingContext<int>();
        foreach (var x in Enumerable.Repeat(value, count))
        {
            await streaming.WriteAsync(x);
        }

        // 完了信号を返す
        return streaming.Result();
    }
}