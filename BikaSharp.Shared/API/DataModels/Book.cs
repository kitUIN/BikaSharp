
namespace BikaSharp.API.DataModels
{
    public class Book
    {
        public Book(Comic co)
        {
            _id = co._id;
            comic = co;
        }
        public string _id { get; set; }
        public Comic comic { get; set; }
        public Dictionary<int, EpisodePage> episodes { get; set; }
        public Dictionary<int, CommentsPage> comments { get; set; }
        public Dictionary<int, PicturePage> pictures { get; set; }

    }


}