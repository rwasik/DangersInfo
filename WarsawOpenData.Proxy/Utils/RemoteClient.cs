using System.Net.Http;
using System.Threading.Tasks;

namespace WarsawOpenData.Proxy.Utils
{
    public class RemoteClient : IRemoteClient
    {
        public async Task<TOut> GetAsync<TOut>(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                return await response.Content.ReadAsAsync<TOut>();
            }
        }
    }
}
