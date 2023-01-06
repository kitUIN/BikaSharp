
namespace BikaSharp.API.DataModels
{
    internal class PicturePage
    {
        public List<Picture> docs { get; set; }
        public int total { get; set; }
        public int limit { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
    }
}
