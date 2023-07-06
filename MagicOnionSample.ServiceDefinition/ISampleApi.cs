using MagicOnion;

namespace MagicOnionSample.ServiceDefinition;

public interface ISampleApi : IService<ISampleApi>
{
    UnaryResult<int> Sum(int x, int y);
}