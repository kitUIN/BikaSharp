
namespace BikaSharp.API.WebServices
{
    public abstract class WebApiBase
    {

        protected static HttpClient _client;

        protected static WebProxy _proxy;
        protected static string _token = string.Empty;
        protected static string _appChannel = "1";
        protected static readonly string BaseUrl = "https://picaapi.picacomic.com/";
        protected static readonly string _appVersion = "2.2.1.2.3.4";
        protected static readonly string ApiKey = "C69BAF41DA5ABD1FFEDC6D2FEA56B";
        protected static readonly string SignKey = "~d}$Q7$eIni=V)9\\RK/P.RM4;9[7|@/CA}b~OW!3?EV`:<>M7pddUBL5n|0/*Cn";
        protected static readonly string _nonce = Guid.NewGuid().ToString().Replace("-", string.Empty);
        static WebApiBase()
        {
#if __IOS__
            var innerHandler = new NSUrlSessionHandler();
#elif __ANDROID__
	    	var innerHandler =	new Xamarin.Android.Net.AndroidMessageHandler();
#else
            var innerHandler = new HttpClientHandler();
#endif
            _client = new HttpClient(innerHandler);
        }

        /// <summary>
        /// bika api encrypt
        /// </summary>
        /// <param name="api">api name</param>
        /// <param name="t">timestamp</param>
        /// <param name="method">http method</param>
        /// <returns></returns>
        private static string BikaEncryption(string api, string t, string method)
        {
            return HmacSHA256(api + t + _nonce + method + ApiKey, SignKey);
        }
        /// <summary>
        /// get bika api header
        /// </summary>
        /// <param name="api">api name</param>
        /// <param name="t">timestamp</param>
        /// <param name="method">http method</param>
        /// <returns></returns>
        private static Dictionary<string, string> BikaHeader(string api,string t,string method)
        {
            var header = new Dictionary<string, string> {
                    {"image-quality", "original"},
                    {"api-key", ApiKey },
                    {"accept", "application/vnd.picacomic.com.v1+json" },
                    {"app-channel", _appChannel},
                    {"time", t},
                    {"signature",  "encrypt"},
                    {"app-version", _appVersion},
                    {"nonce", _nonce},
                    {"app-uuid", "defaultUuid"},
                    {"app-platform", "android"},
                    {"app-build-version", "45"},
                    {"User-Agent", "okhttp/3.8.1"},
                    {"signature", BikaEncryption(api,t,method)},

                };
            if (_token != string.Empty)
            {
                header.Add("Authorization", _token);
            }

            return header;
        }
        /// <summary>
        /// HmacSHA256 encrypt
        /// </summary>
        /// <param name="secret">text need to encrypt</param>
        /// <param name="signKey">signKey</param>
        /// <returns>hex ciphertext</returns>
        private static string HmacSHA256(string secret, string signKey)
        {
            string signRet = string.Empty;
            using (HMACSHA256 mac = new HMACSHA256(Encoding.UTF8.GetBytes(signKey)))
            {
                byte[] hash = mac.ComputeHash(Encoding.UTF8.GetBytes(secret));
                // signRet = Convert.ToBase64String(hash);
                signRet = ToHexString(hash); ;
            }
            return signRet;
        }

        /// <summary>
        /// byte[] -> hex string
        /// </summary>
        /// <param name="bytes">bytes</param>
        /// <returns>hex string</returns>
        public static string ToHexString(byte[] bytes)
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();
                foreach (byte b in bytes)
                {
                    strB.AppendFormat("{0:x2}", b);
                }
                hexString = strB.ToString();
            }
            return hexString;
        }

        protected static HttpRequestMessage CreateRequestMessage(HttpMethod method, string url,string api)
        {
            var httpRequestMessage = new HttpRequestMessage(method, url);
            foreach (var header in BikaHeader(api, DateTime.Now.ToString(), method.ToString()))
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }

            return httpRequestMessage;
        }





        protected static async Task<T> GetAsync<T>(string api)
        {
            using (var request = CreateRequestMessage(HttpMethod.Get, BaseUrl + api, api))
            using (var response = await _client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
                }

                return default;
            }
        }


        protected static async Task<T> PostAsync<T>(string api,Dictionary<string, string> payload)
        {
            using (var request = CreateRequestMessage(HttpMethod.Post, BaseUrl+api, api))
            {
                request.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
                using (var response = await _client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
                    }

                    return default;
                }
            }
        }


        protected static async Task<T> PutAsync<T>(string api,Dictionary<string, string> payload)
        {
            using (var request = CreateRequestMessage(HttpMethod.Put, BaseUrl + api, api))
            {
                request.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
                using (var response = await _client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
                    }

                    return default;
                }
            }
        }

    }
}
