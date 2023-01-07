
namespace BikaSharp.API.DataModels
{
    public class EpisodePage
    {
        public List<Episode> docs { get; set; }
        public int total { get; set; }
        public int limit { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
    }
}
