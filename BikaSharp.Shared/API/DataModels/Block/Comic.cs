
namespace BikaSharp.API.DataModels
{
    public class Comic
    {
        public string _id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int totalViews { get; set; }
        public int totalLikes { get; set; }
        public int pagesCount { get; set; }
        public int epsCount { get; set; }
        public bool finished { get; set; }
        public List<string> categories { get; set; }
        public Thumb thumb { get; set; }
        public string id { get; set; }
        public int likesCount { get; set; }
    }


















}
