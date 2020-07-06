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
    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("expires_in")]
        public object ExpiresIn { get; set; }
        [JsonProperty("scope")]
        public string Scope { get; set; }
        [JsonProperty("allegro_api")]
        public bool AllegroApi { get; set; }
        [JsonProperty("jti")]
        public string Jti { get; set; }

        [JsonIgnore]
        public string AuthorizationToken => "Bearer " + AccessToken;

        public static async Task<Model.Token> GetTokenData(Authorization auth)
        {

            using (HttpClient _client = new HttpClient())
            {        
                _client.DefaultRequestHeaders.Add("Authorization", SD.GetAuthString());
                var response = await _client.PostAsync(SD.tokenUrl + auth.DeviceCode,
                    new FormUrlEncodedContent(new Dictionary<string, string> { { "client_id", SD.clientID } }));
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Model.Token>(json);
            }
        }
    }       
}

