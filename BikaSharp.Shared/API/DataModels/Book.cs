
namespace BikaSharp.API.DataModels
{
    public class Book
    {
        public Book(ComicInfo co)
        {
            Id = co._id;
            Comic = co;
        }
        public string Id { get; set; }
        public int EpIndex { get; set; }
        public int EpTotal { get; set; }
        public int PicIndex { get; set; }
        public int PicTotal { get; set; }
        public int CommentIndex { get; set; }
        public int CommentTotal { get; set; }

        public void SetEpisodes(EpisodePage ep)
        {
            Episodes.Add(ep.page, ep);
            EpIndex = ep.page;
            EpTotal = ep.total;
        }
        public void SetPic(PicturePage pic)
        {
            Pictures.Add(pic.page, pic);
            PicIndex = pic.page;
            PicTotal = pic.total;
        }
        public void SetComment(CommentsPage comment)
        {
            int index = int.Parse(comment.page);
            Comments.Add(index, comment);
            CommentIndex = index;
            CommentTotal = comment.total;
        }



        public ComicInfo Comic { get; set; }
        public Dictionary<int, EpisodePage> Episodes { get; set; }
        public Dictionary<int, CommentsPage> Comments { get; set; }
        public Dictionary<int, PicturePage> Pictures { get; set; }

    }


}