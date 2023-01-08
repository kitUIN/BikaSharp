
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using System.Web;

namespace BikaSharp.API.WebServices
{
    public class BikaClient : WebApiBase
    {
        /// <summary>
        /// Reset Proxy
        /// </summary>
        public static void ResetProxy()
        {
#if __IOS__
            var innerHandler = new NSUrlSessionHandler();
#elif __ANDROID__
            var innerHandler = new Xamarin.Android.Net.AndroidMessageHandler();
#else
            var innerHandler = new HttpClientHandler();
#endif
            _client = new HttpClient(innerHandler);
        }

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

        private static new async Task<BikaResponse<T>> GetAsync<T>(string api)
        {
            return await WebApiBase.GetAsync<T>(api);
        }
        /// <summary>
        /// test <see cref="WebApiBase.BaseUrl"/> network
        /// </summary>
        ///
        /// <returns>time used</returns>
        public static async Task<string> PingBaseUrl()
        {
            return await HeadAsync(BaseUrl);
        }

        /// <summary>
        /// Bika API : Sign-in
        /// </summary>
        /// <remarks>
        /// Login <br/>
        /// if success, <see cref="WebApiBase._token"/> will be set.
        /// </remarks>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <returns><see cref="BikaResponse{T}"/></returns>
        public static async Task<BikaResponse<SignInData>> SignIn(string email, string password)
        {
            BikaResponse<SignInData> res =  await PostAsync<SignInData>("auth/sign-in",
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

        /// <summary>
        /// Bika API : users/profile
        /// </summary>
        /// <remarks>
        /// <see langword="null"/> get self user data, otherwise get user data from id.
        /// </remarks>
        /// <param name="id">user id</param>
        /// <returns><see cref="User"/></returns>
        public static async Task<User> Profile(string id = null)
        {
            BikaResponse<UserData> res = await GetAsync<UserData>($"users/{(id == null ? "" : id + "/")}profile");
            return res.data.user;
        }
        /// <summary>
        /// Bika API : categories
        /// </summary>
        /// <remarks>
        /// get Categories
        /// </remarks>
        /// <returns><see cref="CategoryData"/></returns>
        public static async Task<CategoryData> Categories()
        {
            BikaResponse<CategoryData> res = await GetAsync<CategoryData>("categories");
            return res.data;
        }

        /// <summary>
        /// Bika API : keywords
        /// </summary>
        /// <remarks>
        /// get search keywords
        /// </remarks>
        /// <returns><see cref="KeywordsData"/></returns>
        public static async Task<KeywordsData> Keywords()
        {
            BikaResponse<KeywordsData> res = await GetAsync<KeywordsData>("keywords");
            return res.data;
        }

        public static async Task<KeywordsData> Recommendation(string bookId)
        {
            BikaResponse<KeywordsData> res = await GetAsync<KeywordsData>($"comics/{bookId}/recommendation");
            return res.data;
        }
        /// <summary>
        /// Bika API : comics
        /// </summary>
        /// <remarks>
        /// get comics
        /// </remarks>
        /// <param name="page">index page</param>
        /// <param name="c">comic name</param>
        /// <param name="s"><see cref="SortRule"/>, default:<see cref="SortRule.dd"/></param>
        /// <returns><see cref="ComicsPage"/></returns>
        public static async Task<ComicsPage> Comics(int page, string c, SortRule s = SortRule.dd)
        {

            BikaResponse<ComicsPage> res = await GetAsync<ComicsPage>($"comics?page={page}&c={HttpUtility.UrlEncode(c)}&s={s}");
            return res.data;
        }





        public static string GetAppVersion() => _appVersion;
        public static string GetAppChannel() => _appChannel;
        public static void SetAppChannel(string newChannel) => _appChannel = newChannel;
    }
}
