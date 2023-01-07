namespace BikaSharp.API.DataModels
{
    public class CommentsData
    {
        public CommentsPage comments { get; set; }
        public List<Comment> topComments { get; set; }
    }
}
