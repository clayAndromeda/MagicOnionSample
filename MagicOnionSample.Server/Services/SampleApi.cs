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
}