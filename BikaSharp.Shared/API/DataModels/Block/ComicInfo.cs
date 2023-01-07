
namespace BikaSharp.API.DataModels
{
    public class ComicInfo
    {
        public string _id { get; set; }
        public Creator _creator { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Thumb thumb { get; set; }
        public string author { get; set; }
        public string chineseTeam { get; set; }
        public List<string> categories { get; set; }
        public List<string> tags { get; set; }
        public int pagesCount { get; set; }
        public int epsCount { get; set; }
        public bool finished { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
        public bool allowDownload { get; set; }
        public bool allowComment { get; set; }
        public int totalLikes { get; set; }
        public int totalViews { get; set; }
        public int totalComments { get; set; }
        public int viewsCount { get; set; }
        public int likesCount { get; set; }
        public int commentsCount { get; set; }
        public bool isFavourite { get; set; }
        public bool isLiked { get; set; }
    }


















}
