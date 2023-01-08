


using BikaSharp.API.Exception;

namespace BikaSharp.API.WebServices
{
    public abstract class WebApiBase
    {
        protected static HttpClient _client;

        protected static WebProxy _proxy;
        protected static string _token = null;
        protected static string _appChannel = "3";
        protected const string BaseUrl = "https://picaapi.picacomic.com/";
        protected const string _appVersion = "2.2.1.3.3.4";
        protected const string ApiKey = "C69BAF41DA5ABD1FFEDC6D2FEA56B";
        protected const string SignKey = @"~d}$Q7$eIni=V)9\RK/P.RM4;9[7|@/CA}b~OW!3?EV`:<>M7pddUBL5n|0/*Cn";
        protected static string _nonce = Guid.NewGuid().ToString().Replace("-", string.Empty);
        protected const string local = "local";
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
        /// get bika api header
        /// </summary>
        /// <param name="api">api name</param>
        /// <param name="t">timestamp</param>
        /// <param name="method">http method</param>
        /// <returns></returns>
        private static Dictionary<string, string> BikaHeader(string api,string method)
        {
            string t = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            var header = new Dictionary<string, string> {
                    {"image-quality", "original"},
                    {"api-key", ApiKey },
                    {"accept", "application/vnd.picacomic.com.v1+json" },
                    {"app-channel", _appChannel},
                    {"time", t},
                    {"app-version", _appVersion},
                    {"nonce", _nonce},
                    {"app-uuid", "defaultUuid"},
                    {"app-platform", "android"},
                    {"app-build-version", "45"},
                    {"User-Agent", "okhttp/3.8.1"},

                    {"signature", HmacSHA256(api + t + _nonce + method + ApiKey, SignKey)},

                };
            if (_token != null)
            {
                header.Add("authorization", _token);
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
                byte[] hash = mac.ComputeHash(Encoding.UTF8.GetBytes(secret.ToLower()));
                signRet = Convert.ToHexString(hash).ToLower();
            }
            return signRet;

        }


        protected static HttpRequestMessage CreateRequestMessage(HttpMethod method, string api)
        {
            var httpRequestMessage = new HttpRequestMessage(method, BaseUrl + api);

            foreach (var header in BikaHeader(api, method.ToString()))
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }

            return httpRequestMessage;
        }


        /// <summary>
        /// head async http request
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>network time used</returns>
        protected static async Task<string> HeadAsync(string url)
        {
            string message = $"connect test {url}:{(_proxy != null ? _proxy.Address : local)} -> ";
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Head, url))
                {
                    var now = DateTime.Now;
                    using (var response = await _client.SendAsync(request))
                    {
                        string ms = $"{(DateTime.Now - now).Milliseconds}ms";
                        Log.Information(message + ms);
                        return ms;
                    }
                }

            }
            catch (System.Net.Http.HttpRequestException ep)
            {
                Log.Information(message + "time out");
                return "BikaHttpError.Timeout";
            }
        }
        protected static void BikaHttpError<T>(BikaResponse<T> res)
        {
            switch(res.code)
            {
                case 400:
                    switch(res.error)
                    {
                        case 1019:
                            throw new CantCommentException();
                        case 1031:
                            throw new LevelCommentException();
                        case 1004:
                            throw new SignInException();
                        case 1008:
                            throw new ExistedEmailException();
                        case 1009:
                            throw new ExistedNameException();
                        case 1014:
                            throw new ComicReviewException();
                    }
                    break;
                case 401:
                    if(res.error == 1005)
                    {
                        throw new UnAuthorizedException();
                    }
                    break;
                case 404:
                    if(res.error == 1007)
                    {
                        throw new NotFoundException();
                    }
                    break;
                default:
                    throw new BikaUnknownException(res.message);
            }

        }
        /// <summary>
        /// get async http request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api">api</param>
        /// <returns>T</returns>
        protected static async Task<BikaResponse<T>> GetAsync<T>(string api)
        {
            using (var request = CreateRequestMessage(HttpMethod.Get, api))
            using (var response = await _client.SendAsync(request))
            {
                string resp = await response.Content.ReadAsStringAsync();
                Log.Information($"\n[Get]{api}:\nreturn:\n{resp}");
                var res = JsonSerializer.Deserialize<BikaResponse<T>>(resp);
                if (!response.IsSuccessStatusCode)
                {
                    BikaHttpError(res);

                }
                return res;
            }
        }

        /// <summary>
        /// post async http request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api">api</param>
        /// <param name="payload">post data</param>
        /// <returns>T</returns>
        protected static async Task<BikaResponse<T>> PostAsync<T>(string api,Dictionary<string, string> payload)
        {
            using (var request = CreateRequestMessage(HttpMethod.Post, api))
            {
                string data = JsonSerializer.Serialize(payload);
                request.Content = new StringContent(data, Encoding.UTF8, "application/json");
                request.Content.Headers.Remove("Content-Type");
                request.Content.Headers.Add("Content-Type", "application/json; charset=UTF-8");
                using (var response = await _client.SendAsync(request))
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    Log.Information($"\n[Post]{api}:\npayload:{data}\nreturn:\n{resp}");
                    var res = JsonSerializer.Deserialize<BikaResponse<T>>(resp);
                    if (!response.IsSuccessStatusCode)
                    {
                        BikaHttpError(res);
                    }
                    return res;

                }
            }
        }

        /// <summary>
        /// put async http request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api">api</param>
        /// <param name="payload">put data</param>
        /// <returns>T</returns>
        protected static async Task<BikaResponse<T>> PutAsync<T>(string api,Dictionary<string, string> payload)
        {
            using (var request = CreateRequestMessage(HttpMethod.Put, api))
            {
                string data = JsonSerializer.Serialize(payload);
                request.Content = new StringContent(data, Encoding.UTF8, "application/json");
                request.Content.Headers.Remove("Content-Type");
                request.Content.Headers.Add("Content-Type", "application/json; charset=UTF-8");
                using (var response = await _client.SendAsync(request))
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    Log.Information($"\n[Put]{api}:\npayload:{data}\nreturn:\n{resp}");
                    var res = JsonSerializer.Deserialize<BikaResponse<T>>(resp);
                    if (!response.IsSuccessStatusCode)
                    {
                        BikaHttpError(res);
                    }
                    return res;
                }
        }

    }
}
