
namespace BikaSharp.API.DataModels
{
    public class Comment
    {
        public string _id { get; set; }
        public string content { get; set; }
        public User _user { get; set; }
        public string _comic { get; set; }
        public int totalComments { get; set; }
        public bool isTop { get; set; }
        public bool hide { get; set; }
        public DateTime created_at { get; set; }
        public string id { get; set; }
        public int likesCount { get; set; }
        public int commentsCount { get; set; }
        public bool isLiked { get; set; }
    }



















}
