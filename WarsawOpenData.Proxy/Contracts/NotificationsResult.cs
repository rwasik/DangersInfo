using Newtonsoft.Json;

namespace WarsawOpenData.Proxy.Contracts
{
    public class NotificationsResult
    {
        public bool Success { get; set; }
        public string ResponseDesc { get; set; }
        public string ResponseCode { get; set; }

        [JsonProperty(PropertyName = "result")]
        public NotificationsData Data { get; set; }
    }
}
