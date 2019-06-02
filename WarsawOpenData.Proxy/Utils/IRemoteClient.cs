using System.Threading.Tasks;

namespace WarsawOpenData.Proxy.Utils
{
    public interface IRemoteClient
    {
        Task<TOut> GetAsync<TOut>(string url);
    }
}
