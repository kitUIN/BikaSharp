
namespace BikaSharp.API.DataModels
{
    internal class CommentsPage
    {
        public List<Comment> docs { get; set; }
        public int total { get; set; }
        public int limit { get; set; }
        public string page { get; set; }
        public int pages { get; set; }
    }
}
