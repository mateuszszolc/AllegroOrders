using AllegroOrders.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AllegroOrders.Model
{
    public class Authorization
    {
        [JsonProperty("device_code")]
        public string DeviceCode { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("user_code")]
        public string UserCode { get; set; }
        [JsonProperty("interval")]
        public int Interval { get; set; }
        [JsonProperty("verification_uri")]
        public string VerificationUri { get; set; }
        [JsonProperty("verification_uri_complete")]
        public string VerificationUriComplete { get; set; }

        public static async Task<Model.Authorization> GetAuthorizationData()
        {
            using (HttpClient _client = new HttpClient())
            {
                _client.DefaultRequestHeaders.Add("Authorization", SD.GetAuthString());
                var response = await _client.PostAsync(SD.deviceAuth,
                    new FormUrlEncodedContent(new Dictionary<string, string> { { "client_id", SD.clientID } }));
                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Model.Authorization>(json);
            }
        }
    }
}
