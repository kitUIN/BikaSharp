namespace BikaSharp.API.DataModels
{
    internal class CommentsData
    {
        public CommentsPage comments { get; set; }
        public List<Comment> topComments { get; set; }
    }
}
