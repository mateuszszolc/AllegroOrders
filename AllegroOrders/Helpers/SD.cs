using AllegroOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AllegroOrders.Helpers
{
    public static class SD
    {
        public static readonly string clientID = "486de82bebe047569318e3225d25a05f";
        public static readonly string clientSecret = "vEmri8n5a2gEYU9EsZJyFN7aRUQsVjTcd11nyfRqrt4VlJkhxwmXLHeqVDJeZ3gK";
        public static readonly string deviceAuth = "https://allegro.pl.allegrosandbox.pl/auth/oauth/device";
        public static readonly string tokenUrl = "https://allegro.pl.allegrosandbox.pl/auth/oauth/token?grant_type=urn%3Aietf%3Aparams%3Aoauth%3Agrant-type%3Adevice_code&device_code=";
        public static readonly string offers = "https://api.allegro.pl.allegrosandbox.pl/offers/listing";
        public static readonly string testOffers = "https://api.allegro.pl.allegrosandbox.pl/offers/listing?phrase=czerwona+sukienka";

        public static string GetAuthString()
        {
            string idAndSecret = clientID + ":" + clientSecret;
            byte[] bytes = Encoding.UTF8.GetBytes(idAndSecret);
            return "Basic " + Convert.ToBase64String(bytes);
        }

        public static async void Test(Token token)
        {
            using (HttpClient _client = new HttpClient())
            {
                _client.DefaultRequestHeaders.Add("Accept", "application / vnd.allegro.public.v1+json");
                _client.DefaultRequestHeaders.Add("Authorization", token.AuthorizationToken);
                var response = await _client.GetAsync(testOffers);
                var json = await response.Content.ReadAsStringAsync();                            
            }
        }

    }
}
