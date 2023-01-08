

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
        /// <param name="c">comic name from <see cref="Category.title"/></param>
        /// <param name="s">default: <see cref="SortRule.dd"/></param>
        /// <returns><see cref="ComicsPage"/></returns>
        public static async Task<ComicsPage> Comics(int page, string c, SortRule s = SortRule.dd)
        {

            BikaResponse<ComicsPage> res = await GetAsync<ComicsPage>($"comics?page={page}&c={HttpUtility.UrlEncode(c)}&s={s}");
            return res.data;
        }

        /// <summary>
        /// Bika API : comics/{bookId}
        /// </summary>
        /// <remarks>
        /// get a comic by id
        /// </remarks>
        /// <param name="bookId">comic id</param>
        /// <returns><see cref="Book"/></returns>
        public static async Task<Book> ComicInfo(string bookId)
        {

            BikaResponse<ComicInfoData> res = await GetAsync<ComicInfoData>($"comics/{bookId}");
            return new Book(res.data.comic);
        }
        /// <summary>
        /// Bika API : comics/{bookId}/eps?page={page}
        /// </summary>
        /// <remarks>
        /// get the episodes by book id
        /// </remarks>
        /// <param name="bookId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static async Task<EpisodePage> Episodes(string bookId,int page)
        {

            BikaResponse<EpisodePage> res = await GetAsync<EpisodePage>($"comics/{bookId}/eps?page={page}");
            return res.data;
        }
        /// <summary>
        /// <see cref="Book"/> expansion method to get Episodes
        /// </summary>
        /// <param name="page">index page</param>
        public static async Task Episodes(this Book book, int page)
        {
            EpisodePage res = await Episodes(book.Id, page);
            book.SetEpisodes(res);
        }
        /// <summary>
        /// <see cref="Book"/> expansion method to get next Episode
        /// <remarks>
        /// If you don't initialize <see cref="Episodes(this Book,int)"/>, it will be initialized automatically <br/>
        /// and next will jump to the second page
        /// </remarks>
        /// </summary>
        public static async Task NextEpisode(this Book book)
        {
            if(book.EpIndex == 0)
            {
                await Episodes(book, 1);
            }
            else if (book.EpIndex < book.EpTotal)
            {
                EpisodePage res = await Episodes(book.Id, book.EpIndex + 1);
                book.SetEpisodes(res);
            }
        }
        /// <summary>
        /// <see cref="Book"/> expansion method to get previous Episode
        /// </summary>
        /// <remarks>
        /// If you don't initialize <see cref="Episodes(this Book,int)"/>, it will be initialized automatically <br/>
        /// and will not jump to the previous page
        /// </remarks>
        public static async Task PreEpisode(this Book book)
        {
            if (book.EpIndex == 0)
            {
                await Episodes(book, 1);
            }
            if (book.EpIndex > 2)
            {
                EpisodePage res = await Episodes(book.Id, book.EpIndex + 1);
                book.SetEpisodes(res);
            }
        }



        public static string GetAppVersion() => _appVersion;
        public static string GetAppChannel() => _appChannel;
        public static void SetAppChannel(string newChannel) => _appChannel = newChannel;
    }
}
