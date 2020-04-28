using MagicOnion;

namespace Sample.Shared.Services
{
    public interface IMultiplayService : IService<IMultiplayService>
    {
        UnaryResult<int> SumAsync(int x, int y);
        UnaryResult<int> ProductAsync(int x, int y);
    }
}