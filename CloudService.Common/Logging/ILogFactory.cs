
namespace CloudService.Common.Logging
{
    public interface ILogFactory
    {
        ILogger Create();
        ILogger Create(string name);
    }
}
