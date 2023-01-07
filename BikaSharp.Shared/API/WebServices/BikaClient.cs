
using System.Net;

namespace BikaSharp.API.WebServices
{
    public class BikaClient : WebApiBase
    {
        /// <summary>
        /// Set Proxy
        /// </summary>
        /// <param name="proxy">Proxy Address</param>
        public static void SetProxy(string proxy)
        {
            _proxy = new WebProxy
            {
                Address = new Uri(proxy),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,
            };
#if __IOS__
            var innerHandler = new NSUrlSessionHandler();
#elif __ANDROID__
	    	var innerHandler =	new Xamarin.Android.Net.AndroidMessageHandler
            {
                Proxy = _proxy,
                UseProxy = true
            };
#else
            var innerHandler = new HttpClientHandler
            {
                Proxy = _proxy,
                UseProxy = true
            };
#endif
            _client = new HttpClient(innerHandler);
        }

        public static async Task<string> HeadAsync()
        {
            try
            {

                using (var request = new HttpRequestMessage(HttpMethod.Head, BaseUrl))
                {
                    var now = DateTime.Now;
                    using (var response = await _client.SendAsync(request))
                    {

                        return $"{(DateTime.Now - now).Milliseconds}ms";
                    }
                }

            }
            catch (System.Net.Http.HttpRequestException ep)
            {
                return "BikaHttpError.Timeout";
            }
        }

        /// <summary>
        /// Sign in . if success, <see langword="_token"/> will be set.
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <returns>SignInResponse class</returns>
        public static async Task<SignInResponse> SignIn(string email, string password)
        {
            SignInResponse res =  await PostAsync<SignInResponse>("auth/sign-in",
                new Dictionary<string, string>
                {
                    { "email", email },
                    { "password", password }
                });
            if (res.data != null)
            {
                _token = res.data.token;
            }
            return res;
        }

        public static string GetAppVersion() => _appVersion;
        public static string GetAppChannel() => _appChannel;
        public static void SetAppChannel(string newChannel) => _appChannel = newChannel;
    }
}
